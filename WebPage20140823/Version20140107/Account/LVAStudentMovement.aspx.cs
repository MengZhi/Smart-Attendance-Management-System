using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class LAVStudentMovement : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        static MySqlConnection cn2 = new MySqlConnection(ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                bind();
                GetSummary();        

                Session["AuthorizedStudent"] = "Yes";
            }
        }

        public void GetSummary()
        {
            string SelectStudentId = "select StayInClassTime from studentattendance where StudentId=@StudentId and ClassId=@ClassId;";
            
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn2);

            cn2.Open();
            dataCommand1.Parameters.AddWithValue("@StudentId", GetStudentId(Session["MatricNumber"].ToString()));
            dataCommand1.Parameters.AddWithValue("@ClassId", GetClassId());

            summary.Text = "Time of this student staying in classroom: " + Convert.ToString(dataCommand1.ExecuteScalar());
            cn2.Close();
        }

        public string GetStudentId(string matricNumber)
        {
            string SelectStudentId = "select StudentId from student where MatricNumber=@MatricNumber;";
            string studentId = "";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);



            cn.Open();
            dataCommand1.Parameters.AddWithValue("@MatricNumber", matricNumber);

            studentId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            return studentId;

        }

        public string GetClassId()
        {
            string SelectStudentId = "select ClassId from classinfo where TeachingYear=@TeachingYear and Semester=@Semester and CourseCode=@CourseCode and ClassDate=@ClassDate;";
            string ClassId = "";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);



            cn.Open();
            dataCommand1.Parameters.AddWithValue("@TeachingYear", Session["TeachingYear"].ToString());
            dataCommand1.Parameters.AddWithValue("@Semester", Session["Semester"].ToString());
            dataCommand1.Parameters.AddWithValue("@CourseCode", Session["CourseCode"].ToString());
            dataCommand1.Parameters.AddWithValue("@ClassDate", Session["ClassDate"].ToString());

            ClassId = Convert.ToString(dataCommand1.ExecuteScalar());
            cn.Close();

            return ClassId;

        }

        public void bind()
        {
            try
            {

                MySqlCommand dataCommand4 = new MySqlCommand();
                dataCommand4.Connection = cn;
                dataCommand4.CommandText = "select MovementId, MovementStatus, TimeRecord from attendance.movement join student join classinfo where attendance.movement.StudentId=student.StudentId and attendance.movement.StudentId=@StudentId and attendance.movement.ClassId=@ClassId group by MovementId;";
                //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["MatricNumber"].ToString()));
                dataCommand4.Parameters.AddWithValue("@ClassId", GetClassId());

                //Response.Write(GetStudentId(Session["MatricNumber"].ToString()) + " " + GetClassId());

                MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                System.Data.DataTable my = new System.Data.DataTable();

                cn.Open();
                ada.Fill(my);
                GridView1.DataSource = my;
                //GridView1.
                GridView1.DataKeyNames = new string[] { "MovementId" };//主键
                GridView1.DataBind();
                cn.Close();
            }
            catch
            {
                Response.Write("Have no record!");

            }

        }

        protected void ChooseAnotherStudent_Click(object sender, EventArgs e)
        {
            Response.Redirect("LVAOneClass.aspx");
        }

        protected void refresh_Click(object sender, EventArgs e)
        {
            bind();
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