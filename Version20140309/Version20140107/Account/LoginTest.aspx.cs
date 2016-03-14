using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;


namespace Version20140107.Account
{
    public partial class Login2 : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn.CreateCommand();
        MySqlCommand command2 = cn.CreateCommand();
        

        protected void Page_Load(object sender, EventArgs e)
        {
            CheckDatabaseConnection();
            CurrentTime.Text = "Welcome to my website, it is now " + DateTime.Now;
            //cn.Open();
        }

        public void CheckDatabaseConnection()
        {
          
            using (cn)
            {
                cn.Open();
                Response.Write("database connection successful");
               //while (reader.Read())
                //{
                //    Response.Write(reader.GetString(0));
                //    Response.Write(reader.GetString(1));

                //}
            }
      
        }

        protected void ShowLine()
        {
            Response.Write("Check out the family tree: </br></br>");
            Response.Write(this.GetType().ToString());
            //System.Diagnostics.Debug.Write("zhi meng");
        
        }

        public void clickme_Click(object sender, EventArgs e)
        {
            //Response.Write("hello everyone <br/>");
            //Response.Write(this.textinfo.Text);
            //Response.Write(this.htmltext.Value);
            //Response.Write("<br/>");
            //Response.Write("And the selected item is: <br/>");
            //CheckDatabaseConnection();
            cn.Open();
            command2.CommandText = "INSERT INTO `userinfo` (`UserName`) VALUES (@UserName);";
            //command2.Parameters.AddWithValue("@UserId", textinfo.Text);
            command2.Parameters.AddWithValue("@UserName", TextBox1.Text);
            command2.ExecuteNonQuery();
            cn.Close();
            MySqlDataReader reader = command2.ExecuteReader();
            //Response.Write(this.ddl.SelectedItem.Text);
            //MySqlDataReader reader = CheckDatabaseConnection.command2.ExecuteReader();

        }


        protected void Button1_Click1(object sender, EventArgs e)
        {
            cn.Open();
            command2.CommandText = "INSERT INTO `userinfo` (`UserName`) VALUES (@UserName);";
           
            command2.Parameters.AddWithValue("@UserName", TextBox1.Text);
            command2.ExecuteNonQuery();
            cn.Close();
        }
    }
}