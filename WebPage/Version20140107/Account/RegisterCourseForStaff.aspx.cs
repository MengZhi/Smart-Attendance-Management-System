using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class RegisterCourseForStaff : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        string varSelectStaffId, varSelectCourseId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
                assignStaffId();
                bind2();
            }
        }

        public void assignStaffId()
        {


            string SelectStudentId = "select StaffId from staff where StaffNumber=@StaffNumber;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);
            cn.Open();
            dataCommand1.Parameters.AddWithValue("@StaffNumber", Session["StaffNumber"]);

            varSelectStaffId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            //Response.Write(varSelectStudentId);
        }

        protected void GridView2_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string sqlstr = "delete from staffregisterinformation where SRId='" + GridView2.DataKeys[e.RowIndex].Value.ToString() + "'";

            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);
            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();

            assignStaffId();
            bind2();
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

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            bind();
        }

        protected void finished_Click(object sender, EventArgs e)
        {
            Response.Redirect("EnrollStaff.aspx");
        }

        protected void Register_Click(object sender, EventArgs e)
        {
            assignStaffId();
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;

            string InsertRI = "INSERT INTO attendance.staffregisterinformation (StaffId,CourseId,TeachingYear,Semester,RegisterTime) VALUES (@StaffId,@CourseId,@TeachingYear,@Semester,@RegisterTime);";
            string SelectCourseId = "select CourseId from course where CourseCode=@CourseCode;";



            MySqlCommand dataCommand2 = new MySqlCommand(SelectCourseId, cn);
            MySqlCommand dataCommand3 = new MySqlCommand(InsertRI, cn);

            dataCommand3.Parameters.AddWithValue("@StaffId", varSelectStaffId);


            cn.Open();
            dataCommand2.Parameters.AddWithValue("@CourseCode", grdRow.Cells[1].Text);
            varSelectCourseId = Convert.ToString(dataCommand2.ExecuteScalar());
            dataCommand3.Parameters.AddWithValue("@CourseId", varSelectCourseId);
            dataCommand3.Parameters.AddWithValue("@TeachingYear", SelectTeachingYear.SelectedItem.Text);
            dataCommand3.Parameters.AddWithValue("@Semester", SelectSemester.SelectedItem.Text);
            dataCommand3.Parameters.AddWithValue("@RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
            dataCommand3.ExecuteNonQuery();
            //dataCommand4.ExecuteNonQuery();
            cn.Close();
            bind2();
            //Response.Write(varSelectStudentId + varSelectCourseId);
            
        }

        protected void test_Click(object sender, EventArgs e)
        {
            assignStaffId();
            bind2();
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

        public void bind2()
        {
            MySqlCommand dataCommand4 = new MySqlCommand();
            dataCommand4.Connection = cn;
            dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId;";
            //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
            dataCommand4.Parameters.AddWithValue("@StaffId", varSelectStaffId);

            MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
            System.Data.DataTable my = new System.Data.DataTable();

            cn.Open();
            ada.Fill(my);
            GridView2.DataSource = my;
            //GridView1.
            GridView2.DataKeyNames = new string[] { "SRId" };//主键
            GridView2.DataBind();
            cn.Close();

        }

        protected void FinishSetting_Click(object sender, EventArgs e)
        {
            Session["AuthorizedAdmin"] = "Yes";
            Response.Redirect("SetClass.aspx");
        }


    }
}