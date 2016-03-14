using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Version20140107.Account
{
    
    public partial class RegisterCourseForStudent : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        string varSelectStudentId, varSelectCourseId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
                assignStudentId();
                bind2();
            }
        }

        public void assignStudentId()
        {
            

            string SelectStudentId = "select StudentId from student where MatricNumber=@MatricNumber;";
            
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);
            


            cn.Open();
            dataCommand1.Parameters.AddWithValue("@MatricNumber", Session["MatricNumber"]);
            
            varSelectStudentId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            //Response.Write(varSelectStudentId);
        
        }


        public bool CheckCourseStatus(string Course_Id, string Teaching_Year, string Semester)
        {
            bool flag = false;
            string SelectStudentId = "select * from staffregisterinformation where CourseId=@CourseId and TeachingYear=@TeachingYear and Semester=@Semester;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);
            cn.Open();
            dataCommand1.Parameters.AddWithValue("@CourseId", Course_Id);
            dataCommand1.Parameters.AddWithValue("@TeachingYear", Teaching_Year);
            dataCommand1.Parameters.AddWithValue("@Semester", Semester);

            MySqlDataReader rd = dataCommand1.ExecuteReader();

            flag=rd.HasRows;
            cn.Close();
            return flag;
            
        
        }

        public string GetCourseId(string courseCode)
        {
            string Course_ID="";
            string SelectStudentId = "select CourseId from course where CourseCode=@CourseCode;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);
            cn.Open();
            dataCommand1.Parameters.AddWithValue("@CourseCode", courseCode);
            Course_ID = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();
            return Course_ID;
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            string courseid,teachingyear,semester;
            courseid=GetCourseId((grdRow.FindControl("lblCourseCode") as Label).Text);
            teachingyear = SelectTeachingYear.SelectedItem.Text;
            semester = SelectSemester.SelectedItem.Text;
            

            if (CheckCourseStatus(courseid,teachingyear , semester))
            {
                assignStudentId();
                varSelectCourseId = GetCourseId((grdRow.FindControl("lblCourseCode") as Label).Text);
                string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime,TeachingYear,Semester) VALUES (@StudentId,@CourseId,@RegisterTime,@TeachingYear,@Semester);";
                
                MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

                dataCommand3.Parameters.AddWithValue("@StudentId", varSelectStudentId);

                cn.Open();
               
                dataCommand3.Parameters.AddWithValue("@CourseId", varSelectCourseId);
                dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                dataCommand3.Parameters.AddWithValue("@TeachingYear", SelectTeachingYear.SelectedItem.Text);
                dataCommand3.Parameters.AddWithValue("@Semester", SelectSemester.SelectedItem.Text);
                dataCommand3.ExecuteNonQuery();

                cn.Close();
                bind2();      
            }
            else
            {

                Response.Write("This course is not offered in this semester.");
            }
                    
        }

        public void bind2()
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn;
            dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@StudentId", varSelectStudentId);

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn.Open();
            ada.Fill(my);
            GridView2.DataSource = my;
            //GridView1.
            GridView2.DataKeyNames = new string[] { "RIId" };//主键
            GridView2.DataBind();
            cn.Close();
        
        }

        public void bind()
        {            
            string sqlstr = "select CourseId,CourseCode,CourseName from attendance.course;";
            //string sqlstr = "select StudentId,FirstName from attendance.student;";
            //sqlcon = new SqlConnection(strCon);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, cn);
            //mysqlDataSet myds = new DataSet();
            System.Data.DataSet my = new System.Data.DataSet();

            cn.Open();
            myda.Fill(my, "attendance.course");
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "CourseId" };//主键
            GridView1.DataBind();
            cn.Close();
        }

        

        
        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            bind();
        }
        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow grdRow = GridView2.Rows[e.RowIndex];
            assignStudentId();
            string sqlstr = "delete from registerinformation where RIId='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'";
            string deleteAttendance = "delete from studentattendance where StudentId=@StudentId and CourseId=@CourseId and TeachingYear=@TeachingYear and Semester=@Semester;";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);
            MySqlCommand deleteAttendancecom = new MySqlCommand(deleteAttendance, cn);
            deleteAttendancecom.Parameters.AddWithValue("@StudentId", varSelectStudentId);
            deleteAttendancecom.Parameters.AddWithValue("@CourseId", GetCourseId(grdRow.Cells[1].Text));
            deleteAttendancecom.Parameters.AddWithValue("@TeachingYear", grdRow.Cells[3].Text);
            deleteAttendancecom.Parameters.AddWithValue("@Semester", grdRow.Cells[4].Text);
            cn.Open();
            sqlcom.ExecuteNonQuery();
            deleteAttendancecom.ExecuteNonQuery();
            cn.Close();

            assignStudentId();
            bind2();
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            ////鼠标经过时，行背景色变 
            //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
            ////鼠标移出时，行背景色变 
            // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

            ////当有编辑列时，避免出错，要加的RowState判断 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[5].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of：\"" + e.Row.Cells[1].Text + " " + e.Row.Cells[2].Text + "\"?')");
                }
            }

            //}   
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }

        }

        

        protected void GridView2_RowEditing(object sender, GridViewEditEventArgs e)
        {

        }

        protected void GridView2_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void GridView2_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {

        }

        protected void test_Click(object sender, EventArgs e)
        {
            assignStudentId();
            bind2();
        }

        

        protected void finished_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnrollStudent.aspx");
        }

        protected void MC_Click(object sender, EventArgs e)
        {
            Response.Redirect("MonteCarloSimulation.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
    }
}