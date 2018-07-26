using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Threading;
using System.Windows;
using System.Web.Security;
using System.Web.SessionState;

public partial class MasterPage : System.Web.UI.MasterPage
{
    //public bool LogOutBtn
    //{
    //    get { return LogOut.Visible; }
    //    set => LogOut.Visible = value;
    //}

    public string ULoginBtn
    {
        get { return LoginBtn.Text; }
        set { LoginBtn.Text = value; }
    }

    //public string UNameLogin
    //{
    //    get { return uNameLogin.Text; }
    //    set { uNameLogin.Text = value; }
    //}

    //public string UPassword
    //{
    //    get { return uPasswordLogin.Text; }
    //    set { uPasswordLogin.Text = value; }
    //}

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!Page.IsPostBack)
        //{
        //    Session.Clear();
        //    Session.Abandon();
        //}

        if (!IsPostBack)
        { 
            if (HttpContext.Current.User.Identity.IsAuthenticated == true && Session["userName"] != null)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "hash", "location.hash = '#anchor';", true);
                if (Request.Path.ToString() != "/Home.aspx")
                {
                    welcomeMessage.Text = null;
                    whoAMI.Text = null;
                }

                //int userActivated = 0;
                //string con = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
                //using (SqlConnection newCon = new SqlConnection(con))
                //{
                //    using (SqlCommand cmd = new SqlCommand("SELECT Active FROM [UserLogin] WHERE UserName = @UserName", newCon))
                //    {
                //        cmd.Parameters.AddWithValue("UserName", sessionUName);
                //        newCon.Open();
                //        SqlDataReader dr = cmd.ExecuteReader();
                //        while (dr.Read())
                //        {
                //            userActivated = Convert.ToInt32(dr["Active"]);
                //        }

                //        newCon.Close();
                //    }
                //}
                //if (userActivated == 1)
                //{
                //    sessionUName = Session["userName"].ToString();
                //    LinkButton LoginBtn = new LinkButton();

                //    LoginBtn.Text = "Account Settings";
                //    LoginBtn.OnClientClick = "javascript:void(0); return false;";

                //    LoginBtn.Attributes.Add("OnClick", "AccountSettingsRedirect_Click");
                //}
                //swapLogin
            }
            //else
            //{
            //    LoginBtn.Text = "Login";
            //}
        }
    }

    protected void LogOut_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Clear();
        Server.Transfer("~/Home.aspx");
    }


    protected void JsLoginBtn_Click(object sender, EventArgs e)
    {
        
        var UserName = uNameLogin.Text;
        var Password = uPasswordLogin.Text;


        if (UserName != null && Password != null)
        { 
            int userId = Security.GetUserIdByUsernameAndPassword(UserName, Password);
            if (userId > 0)
            {
                FormsAuthentication.SetAuthCookie(userId.ToString(), true);
                Session["userID"] = userId;
                Session["userName"] = uNameLogin.Text;
                Session["password"] = uPasswordLogin.Text;
                // Now you can put users id in a session-variable or what you prefer
                // and redirect the user to the protected area of your website.
                string sessionUName = Session["userName"].ToString();
                int userActivated = 0;
                string con = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
                using (SqlConnection newCon = new SqlConnection(con))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT Active FROM [UserLogin] WHERE UserName=@UserName", newCon))
                    {
                        cmd.Parameters.AddWithValue("UserName", sessionUName);
                        newCon.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            int activeState = Convert.ToInt32(dr["Active"]);
                            userActivated = activeState;
                        }
                        newCon.Close();
                    }
                }
                if (userActivated == 1)
                {
                    sessionUName = Session["userName"].ToString();
                    LoginBtn.Text = "Account Settings";
                    LoginBtn.OnClientClick = "javascript:void(0); return false;";
                    LoginBtn.Attributes.Add("OnClick", "AccountSettingsRedirect_Click");
                }

                Server.Transfer("~/MembersOnly/OnlyRegisteredCanSeeThis.aspx");
            }
            else
            {
                Server.Transfer("/Home.aspx");
            }
        }
        else if (UserName == null || Password == null)
        {
            uNameLogin.Text = "User Name & Password Required!";
            return;
        }
    }

    protected void AccountSettingsRedirect_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/MembersOnly/Account_Settings.aspx");
    }

    //protected void RegistrationButton_Click(object sender, EventArgs e)
    //{
    //    {
    //        string connString = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
    //        using (SqlConnection myConnection = new SqlConnection(connString))
    //        {

    //            //String insertLine = "INSERT INTO UserLogin VALUES (@UserName, @Password, @Email, @Question, @Answer)";

    //            using (SqlCommand myCommand = new SqlCommand("INSERT INTO UserLogin VALUES (@UserName, @Password, @Email, @Question, @Answer)", myConnection))
    //            {

    //                myCommand.Parameters.AddWithValue("UserName", uNameCreation.Value);
    //                myCommand.Parameters.AddWithValue("Password", uPasswordCreation.Value);
    //                myCommand.Parameters.AddWithValue("Email", uEmail.Value);
    //                myCommand.Parameters.AddWithValue("Question", uSecurityQuestion.Value);
    //                myCommand.Parameters.AddWithValue("Answer", uSecurityAnswer.Value);

    //                myConnection.Open();

    //                int result = myCommand.ExecuteNonQuery();
    //                myCommand.CommandTimeout = 4 * 60;
    //                myConnection.Close();

    //                if (result < 0)
    //                    Console.WriteLine("Error!");

    //            }
    //        }
    //    }
    //    Panel jsRegister = new Panel();

    //    jsRegister.Style.Add("Display", "none");
    //}

    
}