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
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
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

        protected void Register_Click(object sender, EventArgs e)
        {
            assignStudentId();
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;

            string InsertRI = "INSERT INTO attendance.registerinformation (StudentId,CourseId,RegisterTime) VALUES (@StudentId,@CourseId,@RegisterTime);";
            string SelectCourseId = "select CourseId from course where CourseCode=@CourseCode;";



            MySqlCommand dataCommand2 = new MySqlCommand(SelectCourseId, cn);
            MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

            dataCommand3.Parameters.AddWithValue("@StudentId", varSelectStudentId);
            
            
            cn.Open();
            dataCommand2.Parameters.AddWithValue("@CourseCode", grdRow.Cells[1].Text);
            varSelectCourseId = Convert.ToString(dataCommand2.ExecuteScalar());
            dataCommand3.Parameters.AddWithValue("@CourseId", varSelectCourseId);
            dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));       
            dataCommand3.ExecuteNonQuery();
            //dataCommand4.ExecuteNonQuery();
            cn.Close();
            bind2();
            //Response.Write(varSelectStudentId + varSelectCourseId);
            
        }

        public void bind2()
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn;
            dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId;";
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

            string sqlstr = "delete from registerinformation where RIId='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'";

            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);
            cn.Open();
            sqlcom.ExecuteNonQuery();
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

        
    }
}