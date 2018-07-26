using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

public partial class CreateAccount_Activation : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            
            string connStr = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
            string activationCode = !string.IsNullOrEmpty(Request.QueryString["ActivationCode"]) ? Request.QueryString["ActivationCode"] : Guid.Empty.ToString();

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT UserID FROM UserActivation WHERE ActivationCode = @ActivationCode", con))
                {
                    int userID = 0;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@ActivationCode", activationCode);
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            userID = Convert.ToInt32(dr["UserID"]);
                        }
                    }
                    con.Close();

                    if (userID != 0)
                    {
                        using (SqlCommand cmdUpdate = new SqlCommand("UPDATE UserLogin SET Active = @Active WHERE UserIDkey=@UserID", con))
                        {
                            cmdUpdate.Parameters.AddWithValue("@UserID", userID);
                            cmdUpdate.Parameters.AddWithValue("@Active", 1);
                            cmdUpdate.Connection = con;
                            con.Open();
                            cmdUpdate.ExecuteNonQuery();
                            con.Close();
                        }

                        using (SqlCommand cmdDel = new SqlCommand("DELETE FROM UserActivation WHERE ActivationCode = @ActivationCode", con))
                        {
                            using (SqlDataAdapter sda = new SqlDataAdapter())
                            {
                                cmdDel.CommandType = CommandType.Text;
                                cmdDel.Parameters.AddWithValue("@ActivationCode", activationCode);
                                cmdDel.Connection = con;
                                con.Open();
                                int rowsAffected = cmdDel.ExecuteNonQuery();
                                con.Close();
                                if (rowsAffected == 1)
                                {
                                    ltMessage.Text = "Activation Successful";
                                }
                            }
                        }
                    }
                    else
                    {
                        ltMessage.Text = "Invalid Activation Code";
                    }
                }
            }
        }
    }
}