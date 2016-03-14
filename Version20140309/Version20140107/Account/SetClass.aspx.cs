using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class SetClass : System.Web.UI.Page
    {
        static string ConnectionString = @"Data Source=localhost; Database=attendance; User ID=root; Password=karisma123 ";
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

        protected void SetClass_Click(object sender, EventArgs e)
        {
            Button rc = (Button)sender;
            GridViewRow grdRow = (GridViewRow)rc.Parent.Parent;
            Session["FirstName"] = grdRow.Cells[2].Text;
            Session["SecondName"] = grdRow.Cells[3].Text;
            

            Session["StaffNumber"] = (grdRow.FindControl("lblStaffNumber") as Label).Text;
            //Response.Write(strField1);
            Response.Redirect("SetClassForOneLecturer.aspx");
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
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    if (e.Row.RowState == DataControlRowState.Normal || e.Row.RowState == DataControlRowState.Alternate)
            //    {
            //        ((LinkButton)e.Row.Cells[12].Controls[0]).Attributes.Add("onclick", "javascript:return confirm('Are you want to delete the record of：\"" + e.Row.Cells[2].Text + " " + e.Row.Cells[3].Text + "\"?')");
            //    }
            //}

            //}   
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }
        }

        protected void FinishSetting_Click(object sender, EventArgs e)
        {
            Session["AuthorizedAdmin"] = "Yes";
            Response.Redirect("AdminWelcome.aspx");
        }


    }
}