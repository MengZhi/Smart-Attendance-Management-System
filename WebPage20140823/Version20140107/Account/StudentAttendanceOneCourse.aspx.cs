using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class StudentShowAllClasses : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
                Session["AuthorizedStudent"] = "Yes";
            }
        }

        protected void Check_Click(object sender, EventArgs e)
        {

            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["ClassDate"] = (grdRow.FindControl("lblClassDate") as Label).Text;
            Response.Redirect("StudentMovement.aspx");


        }

        public string GetStudentId(string emailAddress)
        {
            string SelectStudentId = "select StudentId from student where EmailAddress=@EmailAddress;";
            string studentId="";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);



            cn.Open();
            dataCommand1.Parameters.AddWithValue("@EmailAddress", emailAddress);

            studentId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            return studentId;
        
        }

      


        public void bind()
        {
            try
            {
                MySqlCommand dataCommand4 = new MySqlCommand();
                dataCommand4.Connection = cn;
                dataCommand4.CommandText = "select StudentAttendanceId, ClassDate, AttendanceStatus from studentattendance join student join classinfo where studentattendance.StudentId=student.StudentId and studentattendance.StudentId=@StudentId and studentattendance.ClassId=classinfo.ClassId and classinfo.CourseCode=@CourseCode and classinfo.TeachingYear=@TeachingYear and classinfo.Semester=@Semester;";
                //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["UserName"].ToString()));
                dataCommand4.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
                dataCommand4.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
                dataCommand4.Parameters.AddWithValue("@CourseCode", Session["CourseCode"].ToString());

                MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                System.Data.DataTable my = new System.Data.DataTable();

                cn.Open();
                ada.Fill(my);
                GridView1.DataSource = my;
                //GridView1.
                GridView1.DataKeyNames = new string[] { "StudentAttendanceId" };//主键
                GridView1.DataBind();
                cn.Close();
            }
            catch
            {
                Response.Write("Have no record!");

            }

        }

        protected void ChooseAnotherCourse_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentAttendanceShowingCourse.aspx");
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

    }
}