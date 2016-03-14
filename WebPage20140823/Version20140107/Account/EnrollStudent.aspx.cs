using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace Version20140107.Account
{
    public partial class EnrollStudent : System.Web.UI.Page
    {
        //static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static string ConnectionString = @"Data Source=us-cdbr-azure-west-a.cloudapp.net; Database=attendance; User ID=b56a71abc69bf4; Password=a3e0f3d0 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn.CreateCommand();
        MySqlCommand command2 = cn.CreateCommand();
        //string htmlStr = "";
        SerialPort port2 = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        string hex = "", value = "", FinalCardID = "", tempHex = "";
       
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (IsPostBack)//delete
            //{
            //    //GetData();
            //    bind();
            //}

            if (!IsPostBack)
            {
                //GetData();
                bind();
            }

            //bind();
            

        }




        protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            bind();
        }


        private void GetData()
        {
            
            System.Collections.ArrayList arr;
            //Array arr;
            if (ViewState["SelectedRecords"] != null)
                arr = (System.Collections.ArrayList)ViewState["SelectedRecords"];
            else
                arr = new System.Collections.ArrayList();
            CheckBox chkAll = (CheckBox)GridView1.HeaderRow
                                .Cells[0].FindControl("chkAll");
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (chkAll.Checked)
                {
                    if (!arr.Contains(GridView1.DataKeys[i].Value))
                    {
                        arr.Add(GridView1.DataKeys[i].Value);
                    }
                }
                else
                {
                    CheckBox chk = (CheckBox)GridView1.Rows[i]
                                       .Cells[0].FindControl("chk");
                    if (chk.Checked)
                    {
                        if (!arr.Contains(GridView1.DataKeys[i].Value))
                        {
                            arr.Add(GridView1.DataKeys[i].Value);
                        }
                    }
                    else
                    {
                        if (arr.Contains(GridView1.DataKeys[i].Value))
                        {
                            arr.Remove(GridView1.DataKeys[i].Value);
                        }
                    }
                }
               
            }
            ViewState["SelectedRecords"] = arr;
        }
        
        

        
        

        private void ShowMessage(int count)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("alert('");
            sb.Append(count.ToString());
            sb.Append(" records deleted.');");
            sb.Append("</script>");
            ClientScript.RegisterStartupScript(this.GetType(),
                            "script", sb.ToString());
        }

        private void DeleteRecord(string StudentId)
        {
            
            string query = "delete from student " +
                            "where MatricNumber=@MatricNumber";
            
            MySqlCommand cmd = new MySqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@MatricNumber", MatricNumber);
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        
        //delete
        
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            
            GridViewRow grdRow = GridView1.Rows[e.RowIndex];
            
            string sqlstr = "delete from student where MatricNumber='" + GridView1.DataKeys[e.RowIndex].Value.ToString() + "'";
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
        //update

        
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            bind();
        }
        protected void CancelEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }
        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string FirstName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbFirstName")).Text;
            string LastName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbLastName")).Text;
            //string UserName = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbLastName")).Text;
            string EmailAddress = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbEmailAddress")).Text;
            string Birthday = ((TextBox)GridView1.Rows[e.RowIndex].FindControl("tbBirthday")).Text;
            string Gender = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGender")).Text;
            string YearOfStudy = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlYearOfStudy")).Text;
            //string SchoolName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
            //string EPC = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
            string MatricNumber = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string sqlstr = "update student set FirstName=@FirstName, LastName=@LastName,EmailAddress=@EmailAddress,Birthday=@Birthday,Gender=@Gender,YearOfStudy=@YearOfStudy where MatricNumber=@MatricNumber;";
            string updateUserinfo = "update userinfo set UserName=@UserName where UserNumber=@UserNumber";

            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);
            MySqlCommand updateUserinfocom = new MySqlCommand(updateUserinfo, cn);

            sqlcom.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = FirstName;
            sqlcom.Parameters.Add("@MatricNumber", MySqlDbType.VarChar).Value = MatricNumber;
            sqlcom.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = LastName;
            sqlcom.Parameters.Add("@EmailAddress", MySqlDbType.VarChar).Value = EmailAddress;
            sqlcom.Parameters.Add("@Gender", MySqlDbType.VarChar).Value = Gender;
            sqlcom.Parameters.Add("@Birthday", MySqlDbType.VarChar).Value = Birthday;
            sqlcom.Parameters.Add("@YearOfStudy", MySqlDbType.VarChar).Value = YearOfStudy;
            updateUserinfocom.Parameters.Add("@UserName", MySqlDbType.VarChar).Value = EmailAddress;
            updateUserinfocom.Parameters.Add("@UserNumber", MySqlDbType.VarChar).Value = MatricNumber;
            //sqlcom.Parameters.Add("@EPC", MySqlDbType.VarChar).Value = EPC;
            //sqlcom.Parameters.Add("@SchoolName", MySqlDbType.VarChar).Value = SchoolName;

            
            
            cn.Open();
            sqlcom.ExecuteNonQuery();
            updateUserinfocom.ExecuteNonQuery();
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
                        ((LinkButton)e.Row.Cells[12].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of：\"" + (e.Row.FindControl("lblFirstName") as Label).Text + " " + (e.Row.FindControl("lblLastName") as Label).Text + "\"?')");
                    }
                }

                //}   
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }

        }
        
        //cancle
        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            bind();
        }
        
        protected void OnPaging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataBind();
            //SetData();
        }


        public void bind()
        {
            //string sqlstr = "select StudentId,FirstName, MatricNumber from attendance.student;";
            string sqlstr = "select StudentId,MatricNumber,FirstName, LastName,EmailAddress,Birthday,Gender,YearOfStudy,SchoolName,EPC from attendance.student;";
            //string sqlstr = "select StudentId,FirstName from attendance.student;";
            //sqlcon = new SqlConnection(strCon);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, cn);
            //mysqlDataSet myds = new DataSet();
            System.Data.DataSet my = new System.Data.DataSet();

            cn.Open();
            myda.Fill(my, "attendance.student");
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "MatricNumber" };//主键
            GridView1.DataBind();
            cn.Close();
        }


        public void bind2()
        {
            string sqlstr = "select StudentId,FirstName, LastName,MatricNumber,EmailAddress,date(Birthday),Gender,YearOfStudy,SchoolName,EPC from attendance.student;";
            //sqlcon = new SqlConnection(strCon);
            MySqlDataAdapter myda = new MySqlDataAdapter(sqlstr, cn);
            //mysqlDataSet myds = new DataSet();
            System.Data.DataSet my= new System.Data.DataSet();
            
            cn.Open();
            myda.Fill(my, "attendance.student");
            GridView1.DataSource = my;
            //GridView1.
            GridView1.DataKeyNames = new string[] { "StudentId" };//主键
            GridView1.DataBind();
            cn.Close();
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

 
        protected void Add_Click(object sender, EventArgs e)
        {
            string maxEPC = "select MAX(EPC) from student";
            int MaxEPC;
            MySqlCommand maxEPCCom = new MySqlCommand(maxEPC, cn);
            cn.Open();
            MaxEPC = (Int32)maxEPCCom.ExecuteScalar()+1;
            cn.Close();

            DateTime todate = DateTime.Now;
            //if (todate.CompareTo(Convert.ToDateTime(Birthday.Text))==1)
            //{
            //    checkDate.Text = "Please Choose a valid date.";
            //}
            //else
            //{
            command.CommandText = "INSERT INTO attendance.student (FirstName, LastName,MatricNumber,EmailAddress,Birthday,Gender,YearOfStudy,SchoolName,EPC,CardID) VALUES (@FirstName, @LastName,@MatricNumber,@EmailAddress,@Birthday,@Gender,@YearOfStudy,@SchoolName,@EPC,@CardID);";
                //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
                command.Parameters.AddWithValue("FirstName", FirstName.Text);
                command.Parameters.AddWithValue("LastName", LastName.Text);
                command.Parameters.AddWithValue("MatricNumber", MatricNumber.Text);
                command.Parameters.AddWithValue("EmailAddress", EmailAddress.Text);
                command.Parameters.AddWithValue("Birthday", Birthday.Text);
                command.Parameters.AddWithValue("Gender", Gender.SelectedItem.Text);
                command.Parameters.AddWithValue("YearOfStudy", YearOfStudy.SelectedItem.Text);
                command.Parameters.AddWithValue("SchoolName", SchoolName.SelectedItem.Text);
                command.Parameters.AddWithValue("EPC", MaxEPC);
                command.Parameters.AddWithValue("CardID", CardID.Text);

                //command2.CommandText = "select * from attendance.student";
                cn.Open();
                MySqlDataReader rd = command.ExecuteReader();
                cn.Close();
                bind();

                command2.CommandText = "INSERT INTO attendance.userinfo (UserNumber,UserName,Password,UserType,RegisterTime) values (@UserNumber,@UserName,@Password,'Student',@RegisterTime);";
                command2.Parameters.AddWithValue("UserNumber", MatricNumber.Text);
                command2.Parameters.AddWithValue("Password", MD5Hash(MatricNumber.Text));
                command2.Parameters.AddWithValue("UserName", EmailAddress.Text);
                command2.Parameters.AddWithValue("RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
                cn.Open();
                MySqlDataReader rd2 = command2.ExecuteReader();
                cn.Close();
            //}


            
        }
        protected void GridView1_RowCreated(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["onmouseover"] = "this.style.cursor='pointer';this.style.textDecoration='underline';";
                e.Row.Attributes["onmouseout"] = "this.style.textDecoration='none';";
                e.Row.ToolTip = "Click to select row";
                e.Row.Attributes["onclick"] = this.Page.ClientScript.GetPostBackClientHyperlink(this.GridView1, "Select$" + e.Row.RowIndex);
            }
        }
        

        


        protected void OnSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void RefashRecord(object sender, EventArgs e)
        {
            //GetData();
            bind();
        }

        protected void Reset_Click(object sender, EventArgs e)
        {
  
            FirstName.Text = "";
            LastName.Text = "";
            MatricNumber.Text = "";
            EmailAddress.Text = "";
            Birthday.Text = "";
            SchoolName.Text = "";
            
        }

        protected void Finish_Click(object sender, EventArgs e)
        {
            Session["AuthorizedAdmin"] = "Yes";
            Response.Redirect("AdminWelcome.aspx");
        }

        protected void RegisterCourse_Click(object sender, EventArgs e)
        {
            //Response.Redirect("RegisterCourseForStudent.aspx");
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            //string strField1 = grdRow.Cells[1].Text;

            Session["FirstName"] = (grdRow.FindControl("lblFirstName") as Label).Text;
            Session["LastName"] = (grdRow.FindControl("lblLastName") as Label).Text;

            Session["MatricNumber"] = (grdRow.FindControl("lblMatricNumber") as Label).Text;
            //Response.Write(strField1);
            Response.Redirect("RegisterCourseForStudent.aspx");
            
        }

        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }

        protected void GetCardID_Click(object sender, EventArgs e)
        {
            CardID.Text = getCardId();
        }
        private void SerialPortProgram()
        {
            //Console.WriteLine("Incoming Data:");
            //port2.Close();
            port2.Open();
            port2.DataReceived += new SerialDataReceivedEventHandler(port_DataReceived);
        }
        public void port_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //port2.Open();
            value += port2.ReadExisting();
        }


        public String getCardId()
        {
            //port2.Close();
            port2.Encoding = System.Text.Encoding.GetEncoding("windows-1252");
            SerialPortProgram();

            //int counter = 0;
            FinalCardID = "";
            string getHexNumber = "";
            Byte[] Request = { 0x07, 0x12, 0x41, 0x01, 0x52, 0xF8, 0x03 };
            Byte[] Uncllision = { 0x0c, 0x22, 0x42, 0x06, 0x93, 0x00, 0x78, 0x01, 0xA6, 0x00, 0xD9, 0x03 };
            Byte[] Stop = { 0x06, 0x32, 0x44, 0x00, 0x8F, 0x03 };
            //Thread.Sleep(500);
            port2.Write(Stop, 0, 6);
            Thread.Sleep(100);
            foreach (char c in value)
            {
                hex = hex + String.Format("{0:x2}", (byte)c);
            }
            tempHex = hex;
            hex = "";
            value = "";
            port2.Write(Request, 0, 7);

            Thread.Sleep(100);
            foreach (char c in value)
            {
                hex = hex + String.Format("{0:x2}", (byte)c);
            }
            tempHex = tempHex + hex;
            hex = "";
            value = "";
            port2.Write(Uncllision, 0, 12);
            Thread.Sleep(100);
            foreach (char c in value)
            {
                hex = hex + String.Format("{0:x2}", (byte)c);
            }
            tempHex = tempHex + hex;
            //Console.Beep();
            //Thread.Sleep(100);           
            char[] final = tempHex.ToCharArray();
            //counter++;
            if (final[0] == '0' && final[1] == '6' && final.Length == 48)
            {

                for (int i = 36; i < 44; i++)
                {
                    FinalCardID = FinalCardID + final[i];
                }

            }
            else
            {
                FinalCardID = "null";
            }
            hex = "";
            tempHex = "";
            value = "";

            port2.Close();
            return FinalCardID;
        }
       
        

        //protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        //{
        //    DateTime dte = Calendar2.SelectedDate;
        //    if (e.Day.Date <= dte)
        //    {
        //        e.Day.IsSelectable = false;
        //        e.Cell.ForeColor = System.Drawing.Color.Gray;
        //    }
        //}


               
    }
}