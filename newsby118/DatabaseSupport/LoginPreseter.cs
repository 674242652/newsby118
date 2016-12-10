using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DatabaseSupport
{
    public class LoginPreseter
    {
        public bool Login(String username,String password)
        {
            //此处需要防止sql注入
            String sql = "select * from [user] where username = '" + username + "\'";
            DataTable dt = DatabasePreseter.DBPreseter.SqlOperation(sql);

            if (dt.Rows.Count > 0 && dt.Rows[0]["password"].ToString() == password)
                return true;
            return false;
        }
    }
}
