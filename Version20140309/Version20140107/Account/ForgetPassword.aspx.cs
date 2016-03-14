using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

//using System.Web.Mail;



namespace Version20140107.Account
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
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

        protected void submit_Click(object sender, EventArgs e)
        {
            bool hasEmailAddress,hasMatricNumber;
            string emailaddress = "select UserName from userinfo where UserName=@UserName";
            string matricnumber = "select MatricNumber from student where MatricNumber=@MatricNumber";

            MySqlCommand emailaddressCom = new MySqlCommand(emailaddress, cn);
            MySqlCommand matricnumberCom = new MySqlCommand(matricnumber, cn);
            emailaddressCom.Parameters.AddWithValue("@UserName", tbemail.Text);
            matricnumberCom.Parameters.AddWithValue("@MatricNumber", tbstaffmatricnumber.Text);
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
            //Response.Write(rd.HasRows);
            //Response.Write(rd2.HasRows);
            cn.Close();

            if (hasMatricNumber == true && hasEmailAddress == true)
            {
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "sendMail()", true);
                //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "checkResult()", true);
                //Response.Write("<script. type='text/javascript'>sendMail();</script>");
                //ClientScript.RegisterStartupScript(ClientScript.GetType(), "myscript", "<script>sendMail();</script>");
                string password = RandomString(6);
                //Response.Write("already sent");
                string changePassword = "UPDATE userinfo SET Password=@Password where UserName=@UserName;";
                MySqlCommand changePasswordcom = new MySqlCommand(changePassword, cn);
                changePasswordcom.Parameters.AddWithValue("@Password", password);
                changePasswordcom.Parameters.AddWithValue("@UserName", tbemail.Text);
                cn.Open();
                MySqlDataReader changePasswordR = changePasswordcom.ExecuteReader();
                cn.Close();

                try
                {
                    MailMessage mMailMessage = new MailMessage();
                    // address of sender 
                    mMailMessage.From = new MailAddress("fypzhimeng@hotmail.com");
                    //mMailMessage.From = new MailAddress("zhimeng1991@gmail.com");
                    // recipient address 
                    mMailMessage.To.Add(new MailAddress(tbemail.Text));
                    mMailMessage.Subject = "New Pasword for Your Account";
                    mMailMessage.Body = "Your new password is: " + password+". Please change your own password.";
                    SmtpClient sc = new SmtpClient("smtp.live.com");
                    //SmtpClient sc = new SmtpClient("smtp.gmail.com");
                    sc.Port = 587;
                    sc.Credentials = new NetworkCredential("fypzhimeng@hotmail.com", "zhimeng123");
                    
                    sc.EnableSsl = true;
                    sc.Send(mMailMessage);
                    lblMessage.Text = "Sent Successful";
                }
                // Check if the bcc value is empty 
                //if (txtBcc.Text != string.Empty)
                //{
                //    // Set the Bcc address of the mail message 
                //    mMailMessage.Bcc.Add(new MailAddress(txtBcc.Text));
                //}
                //// Check if the cc value is empty 
                //if (txtCc.Text != string.Empty)
                //{
                //    // Set the CC address of the mail message 
                //    mMailMessage.CC.Add(new MailAddress(txtCc.Text));
                //} // Set the subject of the mail message 
                //mMailMessage.Subject = "hello";
                //// Set the body of the mail message 
                //mMailMessage.Body = "hello";
                //// Set the format of the mail message body as HTML 
                //mMailMessage.IsBodyHtml = true;
                //// Set the priority of the mail message to normal 
                //mMailMessage.Priority = MailPriority.Normal;
                //// Instantiate a new instance of SmtpClient 
                //SmtpClient mSmtpClient = new SmtpClient();
                //// Send the mail message 
                //try
                //{
                //    mSmtpClient.Send(mMailMessage);
                //}
                catch (Exception ex)
                {
                    ;//log error 
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