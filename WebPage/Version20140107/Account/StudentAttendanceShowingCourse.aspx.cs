using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class StudentAttInfo : System.Web.UI.Page
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
            //string SchoolName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["TeachingYear"] = (grdRow.FindControl("lblTeachingYear") as Label).Text;
            Session["Semester"] = (grdRow.FindControl("lblSemester") as Label).Text;
            Session["CourseCode"] = (grdRow.FindControl("lblCourseCode") as Label).Text;
            Session["CourseName"] = (grdRow.FindControl("lblCourseName") as Label).Text;

            Response.Redirect("StudentAttendanceOneCourse.aspx");
        }

        public void searchBind()
        {
            if (TeachingYear.SelectedValue != "" && Semester.SelectedValue != "")
            {
                try
                {
                    MySqlCommand dataCommand4 = new MySqlCommand();
                    dataCommand4.Connection = cn;
                    dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId and registerinformation.TeachingYear=@TeachingYear and registerinformation.Semester=@Semester;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "RIId" };//主键
                    GridView1.DataBind();
                    cn.Close();
                }
                catch
                {
                    Massege.Text = "Have no record!";

                }
            }
            else if (TeachingYear.SelectedValue == "" && Semester.SelectedValue != "") 
            {
                try
                {
                    MySqlCommand dataCommand4 = new MySqlCommand();
                    dataCommand4.Connection = cn;
                    dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId and registerinformation.Semester=@Semester;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "RIId" };//主键
                    GridView1.DataBind();
                    cn.Close();
                }
                catch
                {
                    Massege.Text = "Have no record!";

                }
            }
            else if (TeachingYear.SelectedValue != "" && Semester.SelectedValue == "")
            {
                try
                {
                    MySqlCommand dataCommand4 = new MySqlCommand();
                    dataCommand4.Connection = cn;
                    dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.TeachingYear=@TeachingYear and registerinformation.CourseId=course.CourseId;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "RIId" };//主键
                    GridView1.DataBind();
                    cn.Close();
                }
                catch
                {
                    Massege.Text = "Have no record!";

                }
            }
            else if (TeachingYear.SelectedValue == "" && Semester.SelectedValue == "")
            {
                try
                {
                    MySqlCommand dataCommand4 = new MySqlCommand();
                    dataCommand4.Connection = cn;
                    dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "RIId" };//主键
                    GridView1.DataBind();
                    cn.Close();
                }
                catch
                {
                    Massege.Text = "Have no record!";

                }
            }
        }


        public void bind()
        {
            try
            {
                MySqlCommand dataCommand4 = new MySqlCommand();
                dataCommand4.Connection = cn;
                dataCommand4.CommandText = "SELECT RIId, CourseCode, CourseName,TeachingYear,Semester from registerinformation join student join course where student.StudentId=registerinformation.StudentId and registerinformation.StudentId=@StudentId and registerinformation.CourseId=course.CourseId;";
                //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                dataCommand4.Parameters.AddWithValue("@StudentId", GetStudentId(Session["UserName"].ToString()));

                MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                System.Data.DataTable my = new System.Data.DataTable();

                cn.Open();
                ada.Fill(my);
                GridView1.DataSource = my;
                //GridView1.
                GridView1.DataKeyNames = new string[] { "RIId" };//主键
                GridView1.DataBind();
                cn.Close();
            }
            catch {
                Massege.Text = "Have no record!";
            
            }

        }

        protected void Search_Click(object sender, EventArgs e)
        {
            searchBind();
        }

        public string GetStudentId(string userName)
        {
            string EmailAddress="";
            string SelectStudentId = "select StudentId from student where EmailAddress=@EmailAddress;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStudentId, cn);
            try
            {
                cn.Open();
                dataCommand1.Parameters.AddWithValue("@EmailAddress", userName);
                EmailAddress = Convert.ToString(dataCommand1.ExecuteScalar());
                cn.Close();
                
                //Massege.Text = EmailAddress;
                return EmailAddress;
            }
            catch {
                EmailAddress = "";
                return EmailAddress;
            }
        }

        protected void ShowAll_Click(object sender, EventArgs e)
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