using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using SimpleCrypto;
using System.Web.UI.HtmlControls;
using System.Web;
using System.Web.SessionState;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Security
{

    //public static string UpdateLabel(string value)
    //{
    //    string newValue = value;
    //    return newValue;
    //}

    public static string HashSHA512(string value)
    {
        var SHA512 = System.Security.Cryptography.SHA512.Create();
        var inputBytes = Encoding.ASCII.GetBytes(value);
        var hash = SHA512.ComputeHash(inputBytes);

        //ICryptoService _PBKDF2;
        
        var sb = new StringBuilder();
        for (var i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        
        return sb.ToString();
    }
    
    public static int GetUserIdByUsernameAndPassword(string UserName, string Password)
    {
        // this is the value we will return
        int userId = 0;

        string con = ConfigurationManager.ConnectionStrings["hetoshiCharityDBConnectionString"].ConnectionString;
        using (SqlConnection newCon = new SqlConnection(con))
        {

            using (SqlCommand newCommand = new SqlCommand("SELECT UserIDkey, UserName, UserPassword, UserGUID " +
                "FROM [UserLogin] WHERE UserName=@UserName", newCon))
            {
                newCommand.Parameters.AddWithValue("UserName", UserName);
                newCon.Open();
                SqlDataReader dr = newCommand.ExecuteReader();
                while (dr.Read())
                {
                    // dr.Read() = we found user(s) with matching username!

                    int dbUserId = Convert.ToInt32(dr["UserIDkey"]);
                    string dbPassword = Convert.ToString(dr["UserPassword"]);
                    string dbUserGuid = Convert.ToString(dr["UserGUID"]);

                    // Now we hash the UserGuid from the database with the password we wan't to check
                    // In the same way as when we saved it to the database in the first place. (see AddUser() function)
                    string hashedPassword = Security.HashSHA512((Password) + dbUserGuid);

                    // if its correct password the result of the hash is the same as in the database
                    if (dbPassword == hashedPassword)
                    {
                        // The password is correct
                        userId = dbUserId;
                    }
                }
                newCon.Close();
            }
        }

        // Return the user id which is 0 if we did not found a user.
        return userId;
    }
}