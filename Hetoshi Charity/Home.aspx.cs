using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.SessionState;

public partial class Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HtmlGenericControl divMaster = (HtmlGenericControl)this.Master.FindControl("jsNewVisitor");

        if (IsPostBack)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false && Session["anonymous"] == null)
            {
                divMaster.Style.Add("display", " inline-grid");
                Session["anonymous"] = 1;
            }
            else if (HttpContext.Current.User.Identity.IsAuthenticated == true && Session["anonymous"] != null)
            {
                divMaster.Style.Add("display", " none");
            }
        }
        else if (!IsPostBack && Session["anonymous"] == null)
        {
            divMaster.Style.Add("display", " inline-grid");
            Session["anonymous"] = 1;
        }

        //HtmlGenericControl loginBtnControl = (HtmlGenericControl)this.Master.FindControl("LoginBtn");
        //WebControl loginBtnControl = (WebControl)this.Master.FindControl("LoginBtn");
        //HtmlGenericControl uName = (HtmlGenericControl)this.Master.FindControl("uNameLogin");

        //if (!IsPostBack)
        //{
        //    if (HttpContext.Current.User.Identity.IsAuthenticated)
        //    {
        //        loginBtnControl.Text = uName.InnerText + " Logged In";
        //    }
        //    else
        //    {
        //        loginBtnControl.InnerText = "Login";
        //    }
        //}
    }
}