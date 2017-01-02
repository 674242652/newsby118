using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSupport
{
    public class ClassificationPreseter
    {
        public static DataTable GetAllClassificatiion()
        {
            String sql = "select * from classification";
            return DatabasePreseter.DBPreseter.SqlOperation(sql);
        }

        public static DataTable GetClassificatiionById(int id)
        {
            String sql = "select * from classification where id="+id;
            return DatabasePreseter.DBPreseter.SqlOperation(sql);
        }


    }
}
