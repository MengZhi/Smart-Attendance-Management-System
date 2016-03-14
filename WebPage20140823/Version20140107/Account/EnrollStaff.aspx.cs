using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;

namespace Version20140107.Account
{
    public partial class EnrollStaff : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn.CreateCommand();
        MySqlCommand command2 = cn.CreateCommand();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //GetData();
                bind();
            }
        }
        
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string FirstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbFirstName")).Text;
            string LastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbLastName")).Text;

            string EmailAddress = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbEmailAddress")).Text;
            string Birthday = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbBirthday")).Text;
            string Gender = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGender")).Text;
            //string YearOfStudy = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlYearOfStudy")).Text;
            //string SchoolName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[7].Controls[0])).Text.ToString().Trim();
            //string EPC = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
            string StaffNumber = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string sqlstr = "update staff set FirstName=@FirstName, LastName=@LastName,EmailAddress=@EmailAddress,Birthday=@Birthday,Gender=@Gender where StaffNumber=@StaffNumber;";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            sqlcom.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = FirstName;
            sqlcom.Parameters.Add("@StaffNumber", MySqlDbType.VarChar).Value = StaffNumber;
            sqlcom.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = LastName;
            sqlcom.Parameters.Add("@EmailAddress", MySqlDbType.VarChar).Value = EmailAddress;
            sqlcom.Parameters.Add("@Gender", MySqlDbType.VarChar).Value = Gender;
            sqlcom.Parameters.Add("@Birthday", MySqlDbType.VarChar).Value = Birthday;
            
            //sqlcom.Parameters.Add("@EPC", MySqlDbType.VarChar).Value = EPC;
            //sqlcom.Parameters.Add("@SchoolName", MySqlDbType.VarChar).Value = SchoolName;



            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                {
                    ((LinkButton)e.Row.Cells[11].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of：\"" + (e.Row.FindControl("lblFirstName") as Label).Text + " " + (e.Row.FindControl("lblLastName") as Label).Text + "\"?')");
                }
            }

            //}   
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow grdRow = GridView1.Rows[e.RowIndex];

            //string sqlstr = "delete from student where MatricNumber='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            string sqlstr = "delete from staff where StaffNumber='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
            string sqlstr2 = "delete from userinfo where UserName='" + grdRow.Cells[4].Text + "'";

            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();
            MySqlCommand sqlcom2 = new MySqlCommand(sqlstr2, cn);
            cn.Open();
            sqlcom2.ExecuteNonQuery();
            cn.Close();
            bind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits
                //for each byte
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }
        protected void Register_Click(object sender, EventArgs e)
        {
            string maxEPC = "select MAX(EPC) from staff";
            int MaxEPC;
            MySqlCommand maxEPCCom = new MySqlCommand(maxEPC, cn);
            cn.Open();
            MaxEPC = (Int32)maxEPCCom.ExecuteScalar() + 1;

            cn.Close();


            command.CommandText = "INSERT INTO attendance.staff (FirstName, LastName,StaffNumber,EmailAddress,Birthday,Gender,SchoolName,EPC) VALUES (@FirstName, @LastName,@StaffNumber,@EmailAddress,@Birthday,@Gender,@SchoolName,@EPC);";
            //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
            command.Parameters.AddWithValue("FirstName", FirstName.Text);
            command.Parameters.AddWithValue("LastName", LastName.Text);
            command.Parameters.AddWithValue("StaffNumber", StaffNumber.Text);
            command.Parameters.AddWithValue("EmailAddress", EmailAddress.Text);
            command.Parameters.AddWithValue("Birthday", Birthday.Text);
            command.Parameters.AddWithValue("Gender", Gender.SelectedItem.Text);           
            command.Parameters.AddWithValue("SchoolName", SchoolName.SelectedItem.Text);
            command.Parameters.AddWithValue("EPC", MaxEPC);

            //command2.CommandText = "select * from attendance.student";
            cn.Open();
            MySqlDataReader rd = command.ExecuteReader();
            cn.Close();
            bind();

            command2.CommandText = "INSERT INTO attendance.userinfo (UserNumber,UserName,Password,UserType,RegisterTime) values (@UserNumber,@UserName,@Password,'Lecturer',@RegisterTime);";
            command2.Parameters.AddWithValue("UserNumber", StaffNumber.Text);
            command2.Parameters.AddWithValue("Password", MD5Hash(StaffNumber.Text));//MD5Hash(StaffNumber.Text)
            command2.Parameters.AddWithValue("UserName", EmailAddress.Text);
            command2.Parameters.AddWithValue("RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
            cn.Open();
            MySqlDataReader rd2 = command2.ExecuteReader();
            cn.Close();

            
        }

        public void bind()
        {
            //string sqlstr = "select StudentId,FirstName, MatricNumber from attendance.student;";
            string sqlstr = "select StaffId,StaffNumber,FirstName, LastName,EmailAddress,Birthday,Gender,SchoolName,EPC from attendance.staff;";
            //string sqlstr = "select StudentId,FirstName from attendance.student;";
            //sqlcon = new SqlConnection(strCon);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, cn);
            //mysqlDataSet myds = new DataSet();
            System.Data.DataSet my = new System.Data.DataSet();

            cn.Open();
            myda.Fill(my, "attendance.staff");
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "StaffNumber" };//主键
            GridView1.DataBind();
            cn.Close();
        }
        protected void Reset_Click(object sender, EventArgs e)
        {
            FirstName.Text = "";
            LastName.Text = "";
            StaffNumber.Text = "";
            EmailAddress.Text = "";
            Birthday.Text = "";
            SchoolName.Text = "";
            
        }

        protected void RegisterCourse_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            //string strField1 = grdRow.Cells[1].Text;

            Session["FirstName"] = (grdRow.FindControl("lblFirstName") as Label).Text;
            Session["LastName"] = (grdRow.FindControl("lblLastName") as Label).Text;

            Session["StaffNumber"] = (grdRow.FindControl("lblStaffNumber") as Label).Text;
            //Response.Write(strField1);
            Response.Redirect("RegisterCourseForStaff.aspx");
        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            Session["AuthorizedAdmin"] = "Yes";
            Response.Redirect("/Account/AdminWelcome.aspx");
        }

        //protected void goMC_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("MonteCarloSimulation.aspx");
        //}

       
    }
}