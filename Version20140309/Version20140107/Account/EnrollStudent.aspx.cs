using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace Version20140107.Account
{
    public partial class EnrollStudent : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
        static MySqlConnection cn = new MySqlConnection(ConnectionString);
        MySqlCommand command = cn.CreateCommand();
        MySqlCommand command2 = cn.CreateCommand();
        //string htmlStr = "";
       
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
            string FirstName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[2].Controls[0])).Text.ToString().Trim();
            string LastName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[3].Controls[0])).Text.ToString().Trim();
            
            string EmailAddress = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[4].Controls[0])).Text.ToString().Trim();
            string Birthday = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[5].Controls[0])).Text.ToString().Trim();
            string Gender = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlGender")).Text;
            string YearOfStudy = ((DropDownList)GridView1.Rows[e.RowIndex].FindControl("ddlYearOfStudy")).Text;
            string SchoolName = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[8].Controls[0])).Text.ToString().Trim();
            string EPC = ((TextBox)(GridView1.Rows[e.RowIndex].Cells[9].Controls[0])).Text.ToString().Trim();
            string MatricNumber = GridView1.DataKeys[e.RowIndex].Value.ToString();

            string sqlstr = "update student set FirstName=@FirstName, LastName=@LastName,EmailAddress=@EmailAddress,Birthday=@Birthday,Gender=@Gender,YearOfStudy=@YearOfStudy,SchoolName=@SchoolName,EPC=@EPC where MatricNumber=@MatricNumber;";
            MySqlCommand sqlcom = new MySqlCommand(sqlstr, cn);

            sqlcom.Parameters.Add("@FirstName", MySqlDbType.VarChar).Value = FirstName;
            sqlcom.Parameters.Add("@MatricNumber", MySqlDbType.VarChar).Value = MatricNumber;
            sqlcom.Parameters.Add("@LastName", MySqlDbType.VarChar).Value = LastName;
            sqlcom.Parameters.Add("@EmailAddress", MySqlDbType.VarChar).Value = EmailAddress;
            sqlcom.Parameters.Add("@Gender", MySqlDbType.VarChar).Value = Gender;
            sqlcom.Parameters.Add("@Birthday", MySqlDbType.VarChar).Value = Birthday;
            sqlcom.Parameters.Add("@YearOfStudy", MySqlDbType.VarChar).Value = YearOfStudy;
            sqlcom.Parameters.Add("@EPC", MySqlDbType.VarChar).Value = EPC;
            sqlcom.Parameters.Add("@SchoolName", MySqlDbType.VarChar).Value = SchoolName;

            
            
            cn.Open();
            sqlcom.ExecuteNonQuery();
            cn.Close();
            GridView1.EditIndex = -1;
            bind();
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行 
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
                ////鼠标经过时，行背景色变 
                //e.Row.Attributes.Add("onmouseover", "this.style.backgroundColor='#E6F5FA'");
                ////鼠标移出时，行背景色变 
               // e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor='#FFFFFF'");

                ////当有编辑列时，避免出错，要加的RowState判断 
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
                    {
                        ((LinkButton)e.Row.Cells[13].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of：\"" + e.Row.Cells[2].Text +" "+ e.Row.Cells[3].Text + "\"?')");
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
        
        

 
        protected void Add_Click(object sender, EventArgs e)
        {
            string maxEPC = "select MAX(EPC) from student";
            int MaxEPC;
            MySqlCommand maxEPCCom = new MySqlCommand(maxEPC, cn);
            cn.Open();
            MaxEPC = (Int32)maxEPCCom.ExecuteScalar()+1;

            cn.Close();
            
            
            
            command.CommandText = "INSERT INTO attendance.student (FirstName, LastName,MatricNumber,EmailAddress,Birthday,Gender,YearOfStudy,SchoolName,EPC) VALUES (@FirstName, @LastName,@MatricNumber,@EmailAddress,@Birthday,@Gender,@YearOfStudy,@SchoolName,@EPC);";
            //command2.CommandText = "select * from attendance.userinfo where UserName='zhimeng1991@gmail.com'";
            command.Parameters.AddWithValue("FirstName", FirstName.Text);
            command.Parameters.AddWithValue("LastName", LastName.Text);
            command.Parameters.AddWithValue("MatricNumber", MatricNumber.Text);
            command.Parameters.AddWithValue("EmailAddress", EmailAddress.Text);
            command.Parameters.AddWithValue("Birthday", Birthday.Text);
            command.Parameters.AddWithValue("Gender", Gender.SelectedItem.Text);
            command.Parameters.AddWithValue("YearOfStudy", YearOfStudy.SelectedItem.Text);
            command.Parameters.AddWithValue("SchoolName", SchoolName.Text);
            command.Parameters.AddWithValue("EPC", MaxEPC);

            //command2.CommandText = "select * from attendance.student";
            cn.Open();
            MySqlDataReader rd = command.ExecuteReader();
            cn.Close();
            bind();

            command2.CommandText = "INSERT INTO attendance.userinfo (UserName,Password,UserType,RegisterTime) values (@UserName,@Password,'Student',@RegisterTime);";
            command2.Parameters.AddWithValue("Password", MatricNumber.Text);
            command2.Parameters.AddWithValue("UserName", EmailAddress.Text);
            command2.Parameters.AddWithValue("RegisterTime", DateTime.Now.ToString("yyyyMMddhhmmss"));
            cn.Open();
            MySqlDataReader rd2 = command2.ExecuteReader();
            cn.Close();
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
            
            Session["FirstName"] = grdRow.Cells[2].Text;
            Session["SecondName"] = grdRow.Cells[3].Text;

            Session["MatricNumber"] = (grdRow.FindControl("lblMatricNumber") as Label).Text;
            //Response.Write(strField1);
            Response.Redirect("RegisterCourseForStudent.aspx");
            
        }

        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }

        protected void test_Click(object sender, EventArgs e)
        {
            //Response.Write(GridView1.Rows[e.RowIndex].Cells[4].ToString());
        }
               
    }
}