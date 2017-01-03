using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data;
using System.Web.SessionState;
namespace DatabaseSupport
{
    public class LoginPreseter :IRequiresSessionState
    {
        public int Login(String username,String password)
        {
            //此处需要防止sql注入
            String sql = "select * from [user] where username = '" + username + "\'";
            DataTable dt = DatabasePreseter.DBPreseter.SqlOperation(sql);

            if (dt.Rows.Count > 0 && dt.Rows[0]["password"].ToString() == password)
            {
                System.Web.HttpContext.Current.Session["User"] = dt;
                int type = (int)dt.Rows[0]["category"];
                return type;
            }
            return -1;
        }
    }
}
