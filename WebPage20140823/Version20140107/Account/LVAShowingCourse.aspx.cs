using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class LAVShowingCourse : System.Web.UI.Page
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
                Session["AuthorizedLecturer"] = "Yes";
            }
        }

        

        protected void CheckClass_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["TeachingYear"] = (grdRow.FindControl("lblTeachingYear") as Label).Text;
            Session["Semester"] = (grdRow.FindControl("lblSemester") as Label).Text;
            Session["CourseCode"] = (grdRow.FindControl("lblCourseCode") as Label).Text;
            Session["CourseName"] = (grdRow.FindControl("lblCourseName") as Label).Text;

            Response.Redirect("LVAShowAllClasses.aspx");
        }

        

        public void searchBind()
        {
            if (TeachingYear.SelectedValue != "" && Semester.SelectedValue != "")
            {
                try
                {
                    MySqlCommand dataCommand4 = new MySqlCommand();
                    dataCommand4.Connection = cn;
                    dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId and staffregisterinformation.TeachingYear=@TeachingYear and staffregisterinformation.Semester=@Semester;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StaffId", GetStaffId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "SRId" };//主键
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
                    dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId and  staffregisterinformation.Semester=@Semester;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StaffId", GetStaffId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "SRId" };//主键
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
                    dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId and staffregisterinformation.TeachingYear=@TeachingYear;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StaffId", GetStaffId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "SRId" };//主键
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
                    dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId;";
                    //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                    dataCommand4.Parameters.AddWithValue("@StaffId", GetStaffId(Session["UserName"].ToString()));
                    dataCommand4.Parameters.AddWithValue("@TeachingYear", TeachingYear.SelectedItem.Text);
                    dataCommand4.Parameters.AddWithValue("@Semester", Semester.SelectedItem.Text);

                    MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                    System.Data.DataTable my = new System.Data.DataTable();

                    cn.Open();
                    ada.Fill(my);
                    GridView1.DataSource = my;
                    //GridView1.
                    GridView1.DataKeyNames = new string[] { "SRId" };//主键
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
                dataCommand4.CommandText = "SELECT SRId, CourseCode, CourseName,TeachingYear,Semester from staffregisterinformation join staff join course where staff.StaffId=staffregisterinformation.StaffId and staffregisterinformation.StaffId=@StaffId and staffregisterinformation.CourseId=course.CourseId;";
                //MySqlCommand dataCommand4 = new MySqlCommand(selectRII, cn);
                dataCommand4.Parameters.AddWithValue("@StaffId", GetStaffId(Session["UserName"].ToString()));

                MySqlDataAdapter ada = new MySqlDataAdapter(dataCommand4);
                System.Data.DataTable my = new System.Data.DataTable();

                cn.Open();
                ada.Fill(my);
                GridView1.DataSource = my;
                //GridView1.
                GridView1.DataKeyNames = new string[] { "SRId" };//主键
                GridView1.DataBind();
                cn.Close();
            }
            catch
            {
                Massege.Text = "Have no record!";

            }

        }

        public string GetStaffId(string userName)
        {
            string EmailAddress = "";
            string SelectStaffId = "select StaffId from staff where EmailAddress=@EmailAddress;";
            MySqlCommand dataCommand1 = new MySqlCommand(SelectStaffId, cn);
            try
            {
                cn.Open();
                dataCommand1.Parameters.AddWithValue("@EmailAddress", userName);
                EmailAddress = Convert.ToString(dataCommand1.ExecuteScalar());
                cn.Close();

                //Massege.Text = EmailAddress;
                return EmailAddress;
            }
            catch
            {
                EmailAddress = "";
                return EmailAddress;
            }
        }

        protected void Search_Click(object sender, EventArgs e)
        {
            searchBind();
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