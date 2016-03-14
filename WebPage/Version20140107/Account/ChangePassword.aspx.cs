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
    public partial class ChangePassword : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";

        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 "; 
        static MySqlConnection cn = new MySqlConnection(ConnectionString);

        static string prevPage = String.Empty;
        //static string userName="";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                prevPage = Request.UrlReferrer.ToString();
                //userName = Session["UserName"].ToString();
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


        public bool checkOldPassword()
        { 
            string oldPassword="",enterOldPassword="";

            enterOldPassword = MD5Hash(tbOldPassword.Text);

            string sqlAdminNumber = "select Password from userinfo where UserName=@UserName";
            MySqlCommand sqlAdminNumbercom = new MySqlCommand(sqlAdminNumber, cn);
            sqlAdminNumbercom.Parameters.Add("@UserName", Session["UserName"].ToString());

            cn.Open();
            //userNumber = Convert.ToString(sqlAdminNumbercom.ExecuteScalar());
            //MySqlDataReader result = sqlAdminNumbercom.ExecuteReader();
            oldPassword = sqlAdminNumbercom.ExecuteScalar().ToString();
            cn.Close();
            //oldPassword=result[0].ToString();
            //Response.Write(oldPassword);


            if (oldPassword == enterOldPassword)
            {
               // Response.Write(oldPassword);
                return true;
            }
            else
            {
        
                return false;
            }
        
        }

        public bool checkNewPasswordSame()
        {
            if (tbNewPassword.Text==tbReenter.Text)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        
        }

        protected void passwordChange_Click(object sender, EventArgs e)
        {
            if (checkOldPassword() == true)
            {
                if (checkNewPasswordSame()==true)
                {
                    string changePassword = "update userinfo set Password=@Password where UserName=@UserName;";
                    MySqlCommand changePasswordcom = new MySqlCommand(changePassword, cn);
                    changePasswordcom.Parameters.Add("@Password", MD5Hash(tbNewPassword.Text));
                    changePasswordcom.Parameters.Add("@UserName", Session["UserName"].ToString());
                    cn.Open();
                    changePasswordcom.ExecuteNonQuery();
                    cn.Close();
                    message.Text = "Your password was changed successfully";
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    message.Text = "Your new passwoed is not matching";
                }
            }
            else
            {
                message.Text = "Your old password is wrong";
            }
        }

        protected void cancle_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage); 
            //Response.Write(Session["UserName"].ToString());
        }
    }
}