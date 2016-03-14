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
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}