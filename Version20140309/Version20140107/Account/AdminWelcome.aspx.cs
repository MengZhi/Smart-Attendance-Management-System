using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Version20140107.Account
{
    public partial class AdminWellcome : System.Web.UI.Page
    {
        //static string userName;
        //string Authorized;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                
                if (((string)Session["AuthorizedAdmin"]) != "Yes")
                //if (Session["Authorized"].ToString()!="Yes")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    Session["AuthorizedAdmin"] = "No";
                }
            }
        }

        protected void logout_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }
    }
}