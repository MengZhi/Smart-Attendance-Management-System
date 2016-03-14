using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Version20140107.Account
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
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

        public bool checkOldPassword()
        { 
            string oldPassword="",enterOldPassword="";

            enterOldPassword = tbOldPassword.Text;

            string sqlAdminNumber = "select Password from userinfo where UserName=@UserName";
            MySqlCommand sqlAdminNumbercom = new MySqlCommand(sqlAdminNumber, cn);
            sqlAdminNumbercom.Parameters.Add("@UserName", Session["UserName"].ToString());

            cn.Open();
            //userNumber = Convert.ToString(sqlAdminNumbercom.ExecuteScalar());
            //MySqlDataReader result = sqlAdminNumbercom.ExecuteReader();
            oldPassword=sqlAdminNumbercom.ExecuteScalar().ToString();
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
                    changePasswordcom.Parameters.Add("@Password", tbNewPassword.Text );
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