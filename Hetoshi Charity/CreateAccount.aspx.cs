using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.ComponentModel;
using System.Diagnostics;
using System.Security;
using System.Threading;
using System.Data;

public partial class CreateAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void RegistrationButton_Click(object sender, EventArgs e)
    {
        {
            int userID = 0;
            string connString = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
            using (SqlConnection myConnection = new SqlConnection(connString))
            {

                //String insertLine = "INSERT INTO UserLogin VALUES (@UserName, @Password, @Email, @Question, @Answer)";
               
                using (SqlCommand myCommand = new SqlCommand("Insert_User", myConnection))
                {

                    Guid userGuid = System.Guid.NewGuid();
                    string hashedPW = Security.HashSHA512((uPasswordTxt.Text) + userGuid.ToString());

                    myCommand.CommandType = System.Data.CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("UserName", uNameTxt.Text.Trim());
                    myCommand.Parameters.AddWithValue("Password", hashedPW.Trim());
                    myCommand.Parameters.AddWithValue("Email", uEmailTxt.Text.Trim());
                    myCommand.Parameters.AddWithValue("Question", userQuestion.Text.Trim());
                    myCommand.Parameters.AddWithValue("Answer", userAnswer.Text.Trim());
                    myCommand.Parameters.AddWithValue("Active", 0);
                    myCommand.Parameters.AddWithValue("UserGUID", userGuid);
                    
                    myConnection.Open();
                    //int result = myCommand.ExecuteNonQuery();
                    userID = Convert.ToInt32(myCommand.ExecuteScalar());
                    myCommand.CommandTimeout = 4 * 10;
                    myConnection.Close();
                }
            }

            string message = string.Empty;
            switch (userID)
            {
                case -1:
                    message = "Username already exists.\\nPlease choose a different username.";
                    break;
                case -2:
                    message = "Email address already used.";
                    break;
                default:
                    message = "Registration successful.  Activation email has been sent.";
                    SendActivationEmail(userID);
                    break;
            }
            ClientScript.RegisterStartupScript(GetType(), "alert", "alert('" + message + "');", true);
            createAccountValidation.Text = message + " " + userID;
        }

        //using (MailMessage mail = new MailMessage())
        //{
        //    mail.From = new MailAddress("dannarhetoshi@gmail.com");
        //    mail.To.Add(uEmailTxt.Text);
        //    mail.Subject = "DannarHetoshi.com Email Verification Required";
        //    mail.Body = "<p> Hi " + uNameTxt.Text + "!<p> Help us secure your dannarhetoshi account by verifying your email address: " + uEmailTxt.Text + ".  " +
        //        "This will let you receive notifications and password resets from dannarhetoshi.com." + 
        //        "<p>" + "If you have received this email message in error, please disregard.";
        //    mail.IsBodyHtml = true;

        //    using (SmtpClient smtp = new SmtpClient("DannarHetoshi@gmail.com", 587))
        //    {
        //        string emailPassword = ConfigurationManager.AppSettings.Get("emailPassword");
        //        smtp.Credentials = new NetworkCredential("DannarHetoshi@gmail.com", emailPassword);
        //        smtp.EnableSsl = true;
        //        smtp.Send(mail);
        //    }
        //}

        uPasswordTxt.Text = "";
        uCNFPasswordTxt.Text = "";
        Response.ClearContent();
        Thread.Sleep(20000);
        Server.Transfer("Home.aspx");

    }

    private void SendActivationEmail(int userID)
    {
        string connStr = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
        string activationCode = Guid.NewGuid().ToString();
        string emailPassword = ConfigurationManager.AppSettings.Get("emailPassword").ToString();

        using (SqlConnection con = new SqlConnection(connStr))
        { 
            using (SqlCommand cmd = new SqlCommand("INSERT INTO UserActivation VALUES(@UserID, @ActivationCode)"))
            {
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", userID);
                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
        }

        using (MailMessage mail = new MailMessage("DannarHetoshi@gmail.com", uEmailTxt.Text))
        {
            mail.Subject = "Account Activation";
            string body = "Hello " + uNameTxt.Text.Trim() + ",";
            body += "<br /><br />Please click the following link to activate your account";
            body += "<br /><a href = '" + Request.Url.AbsoluteUri.Replace("CreateAccount.aspx", "CreateAccount_Activation.aspx?ActivationCode=" + 
                activationCode) + "'>Click here to activate your account.</a>";
            body += "<br /><br />Thanks";
            body += "<br /><br />If you believe you have received this email in error, please disregard.";
            mail.Body = body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            NetworkCredential credentials = new NetworkCredential("DannarHetoshi@gmail.com", emailPassword);
            smtp.UseDefaultCredentials = true;
            smtp.Credentials = credentials;
            smtp.Port = 587;
            smtp.Send(mail);
        }
    }

}