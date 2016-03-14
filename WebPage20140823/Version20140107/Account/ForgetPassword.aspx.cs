using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;

//using System.Web.Mail;



namespace Version20140107.Account
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);


        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private static Random random = new Random((int)DateTime.Now.Ticks);//thanks to McAden
        private string RandomString(int size)
        {
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }

            return builder.ToString();
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


        protected void submit_Click(object sender, EventArgs e)
        {
            bool hasEmailAddress,hasMatricNumber,hasStaffNumber;
            string emailaddress = "select UserName from userinfo where UserName=@UserName";
            string matricnumber = "select MatricNumber from student where MatricNumber=@MatricNumber";
            string StaffNumber = "select StaffNumber from staff where StaffNumber=@StaffNumber";

            MySqlCommand emailaddressCom = new MySqlCommand(emailaddress, cn);
            MySqlCommand matricnumberCom = new MySqlCommand(matricnumber, cn);
            MySqlCommand StaffNumberCom = new MySqlCommand(StaffNumber, cn);

            emailaddressCom.Parameters.AddWithValue("@UserName", tbemail.Text);
            matricnumberCom.Parameters.AddWithValue("@MatricNumber", tbstaffmatricnumber.Text);
            StaffNumberCom.Parameters.AddWithValue("@StaffNumber", tbstaffmatricnumber.Text);
            cn.Open();
            MySqlDataReader rd = emailaddressCom.ExecuteReader();
            //MySqlDataReader rd2 = sqlcom2.ExecuteReader();

            //Response.Write(rd.HasRows);
            hasEmailAddress = rd.HasRows;
            //Response.Write(rd2.HasRows);
            cn.Close();

            cn.Open();
            //MySqlDataReader rd = sqlcom.ExecuteReader();
            MySqlDataReader rd2 = matricnumberCom.ExecuteReader();
            hasMatricNumber = rd2.HasRows;
            cn.Close();

            cn.Open();
            //MySqlDataReader rd = sqlcom.ExecuteReader();
            MySqlDataReader rd3 = StaffNumberCom.ExecuteReader();
            hasStaffNumber = rd3.HasRows;
            cn.Close();

            if ((hasMatricNumber == true && hasEmailAddress == true) || (hasStaffNumber == true && hasEmailAddress == true))
            {
                
                string password = RandomString(6);
                

                try
                {
                    MailMessage mMailMessage = new MailMessage();
                    // address of sender 
                    mMailMessage.From = new MailAddress("fypzhimeng@hotmail.com");                   
                    mMailMessage.To.Add(new MailAddress(tbemail.Text));
                    mMailMessage.Subject = "New Pasword for Your Account";
                    mMailMessage.Body = "Your new password is: " + password+". Please change your own password.";
                    SmtpClient sc = new SmtpClient("smtp.live.com");                 
                    sc.Port = 587;
                    sc.Credentials = new NetworkCredential("fypzhimeng@hotmail.com", "zhimeng123");
                    
                    sc.EnableSsl = true;
                    sc.Send(mMailMessage);
                    lblMessage.Text = "Sent Successful";

                    string changePassword = "UPDATE userinfo SET Password=@Password where UserName=@UserName;";
                    MySqlCommand changePasswordcom = new MySqlCommand(changePassword, cn);
                    changePasswordcom.Parameters.AddWithValue("@Password", MD5Hash(password));
                    changePasswordcom.Parameters.AddWithValue("@UserName", tbemail.Text);
                    cn.Open();
                    MySqlDataReader changePasswordR = changePasswordcom.ExecuteReader();
                    cn.Close();

                }
                
                catch (Exception ex)
                {                    
                    lblMessage.Text = ex.Message;
                }
                Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "checkResult()", true);

            }
            else if (hasMatricNumber != true || hasEmailAddress != true)
            {
                lblMessage.Text = "Your matric/stuff number and/or E-mail address have error.";
            }



        }

        protected void finish_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}