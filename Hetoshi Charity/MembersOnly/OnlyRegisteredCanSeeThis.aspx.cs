using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OnlyRegisteredCanSeeThis : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Welcome.Text = "Welcome " + Session["userName"].ToString();
        //if (!Page.IsPostBack)
        //{
        //    Master.LogOutBtn = false;
        //}
    }

    protected void LogoutBtn_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Response.Redirect("/Home.aspx", true);
    }
}