using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DatabaseSupport
{
    public class UserPreseter
    {
        public static DataTable GetAllWaitRegisteredUser()
        {

            String sql = "select * from userwaitregistered";
            return DatabasePreseter.DBPreseter.SqlOperation(sql);


        }


    }
}
