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
    public partial class Login : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn.CreateCommand();
        string userNumber, userFirstName, userLastName;
        //MySqlCommand command2 = cn.CreateCommand();
        


        protected void Page_Load(object sender, EventArgs e)
        {

        

            
        }

        public void selectAdminInfo()
        {
            string sqlAdminNumber = "select MatricNumber,FirstName,LastName from student where EmailAddress=@EmailAddress";
            MySqlCommand sqlAdminNumbercom = new MySqlCommand(sqlAdminNumber, cn);
            sqlAdminNumbercom.Parameters.Add("EmailAddress", TextBox1.Text);

            cn.Open();
            //userNumber = Convert.ToString(sqlAdminNumbercom.ExecuteScalar());
            MySqlDataReader result = sqlAdminNumbercom.ExecuteReader();
            cn.Close();

            userNumber = result["MatricNumber"].ToString();
            userFirstName=result["FirstName"].ToString();
            userLastName=result["LastName"].ToString();



        }

        public void selectStudentInfo()
        {
            string sqlAdminNumber = "select MatricNumber,FirstName,LastName from student where EmailAddress=@EmailAddress";
            MySqlCommand sqlAdminNumbercom = new MySqlCommand(sqlAdminNumber, cn);
            sqlAdminNumbercom.Parameters.Add("EmailAddress", TextBox1.Text);

            cn.Open();
            //userNumber = Convert.ToString(sqlAdminNumbercom.ExecuteScalar());
            MySqlDataReader result = sqlAdminNumbercom.ExecuteReader();
            cn.Close();

            userNumber = result["MatricNumber"].ToString();
            userFirstName = result["FirstName"].ToString();
            userLastName = result["LastName"].ToString();
        }

        public void selectStuffInfo()
        {
            string sqlAdminNumber = "select StaffNumber,FirstName,LastName from staff where EmailAddress=@EmailAddress";
            MySqlCommand sqlAdminNumbercom = new MySqlCommand(sqlAdminNumber, cn);
            sqlAdminNumbercom.Parameters.Add("EmailAddress", TextBox1.Text);

            cn.Open();
            //userNumber = Convert.ToString(sqlAdminNumbercom.ExecuteScalar());
            MySqlDataReader result = sqlAdminNumbercom.ExecuteReader();
            cn.Close();

            userNumber = result["MatricNumber"].ToString();
            userFirstName = result["FirstName"].ToString();
            userLastName = result["LastName"].ToString();
        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            
            command.CommandText = "select * from userinfo where UserName=@UserName and Password=@Password and UserType=@UserType";
            //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
            command.Parameters.AddWithValue("UserName", TextBox1.Text);
            command.Parameters.AddWithValue("Password", MD5Hash(TextBox2.Text));
            command.Parameters.AddWithValue("UserType", UserType.SelectedItem.Text);
            cn.Open();
            MySqlDataReader rd = command.ExecuteReader();
            
            
            if (UserType.SelectedItem.Text == "Student" && rd.HasRows)
            {
                cn.Close();
                WrongPassword.Text = "Login Successful";
                Session["UserName"] = TextBox1.Text;
                Session["AuthorizedStudent"] = "Yes";
                Response.Redirect("StudentWelcome.aspx");

                
                
            }
            else if (UserType.SelectedItem.Text == "Lecturer" && rd.HasRows)
            {
                cn.Close();
                WrongPassword.Text = "Login Successful";
                Session["UserName"] = TextBox1.Text;
                Session["AuthorizedLecturer"] = "Yes";
                Response.Redirect("LecturerWelcome.aspx");

            }
            else if (UserType.SelectedItem.Text == "Administrator" && rd.HasRows)
            {
                cn.Close();
                WrongPassword.Text = "Login Successful";
                Session["UserName"] = TextBox1.Text;
                Session["AuthorizedAdmin"] = "Yes";
                Response.Redirect("AdminWelcome.aspx");
                
            }
            else
            {
                cn.Close();
                WrongPassword.Text = "Wrong Password";
                //Response.Write("ERROR!");
            }
            
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
        
    }
}