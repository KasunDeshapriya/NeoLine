using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Service.Models;
using System.Data;

namespace Service.DataAccess
{
    public class Login
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Context"].ConnectionString);

        public int userLogin(User us)
        {
            SqlCommand com = new SqlCommand("Sp_User_Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName",us.UserName);
            com.Parameters.AddWithValue("@Password", us.Password);
            SqlParameter obLogin = new SqlParameter();
            obLogin.ParameterName = "@Isvalied";
            obLogin.Direction = ParameterDirection.Output;
            obLogin.SqlDbType = SqlDbType.Bit;
            com.Parameters.Add(obLogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(obLogin.Value);
            con.Close();
            return res;




        }

    }
}
