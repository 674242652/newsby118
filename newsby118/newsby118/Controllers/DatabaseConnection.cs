using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DatabaseSupport
{
    public class DatabaseConnection
    {
        private SqlConnection con;
        //SqlDataAdapter 另一种更新方法，更新单表
        public DatabaseConnection()
        {
            con = new SqlConnection();
            //con.ConnectionString = "server=localhost;database=newsReleaseSystem;uid=sa;pwd=123456";
            con.ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
            con.Open();
        }
        public DataTable Select(string sql)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter myAd
                = new SqlDataAdapter(sql, con);
            myAd.Fill(dt);
            return dt;
        }
    }
}
