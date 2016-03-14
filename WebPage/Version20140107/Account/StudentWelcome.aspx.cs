using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class StudentWellcome : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (((string)Session["AuthorizedStudent"]) != "Yes")
                //if (Session["Authorized"].ToString()!="Yes")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Session["AuthorizedStudent"] = "No";
                    GetStudentNameMatricNumber();
                }
            }
        }

        public void GetStudentNameMatricNumber()
        {
            try
            {
                string sqlstr = "SELECT FirstName,LastName,MatricNumber FROM student WHERE EmailAddress=@EmailAddress ";
                MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);
                sqlcom.Parameters.AddWithValue("@EmailAddress", Session["UserName"]);

                
                cn.Open();
                MySqlDataReader currentLoggedInUser = sqlcom.ExecuteReader();
                currentLoggedInUser.Read();
                
                    string userName = currentLoggedInUser.GetString(0) + " " + currentLoggedInUser.GetString(1);
                    string matricNumber = currentLoggedInUser.GetString(2);
              
                cn.Close();
                Session["StudentName"] = userName;
                Session["MatricNumber"] = matricNumber;

                
                StudentName.Text = Session["StudentName"].ToString();
                MatricNumber.Text = Session["MatricNumber"].ToString();

            }
            catch
            {

                Response.Write("ERROR;");

            }  
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}