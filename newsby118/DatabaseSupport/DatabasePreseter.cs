using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DatabaseSupport
{
    public class DatabasePreseter
    {
        private DatabaseConnection _dbConnect;
        private static DatabasePreseter _dbPreseter;
        public static DatabasePreseter DBPreseter{
            get{
                if (_dbPreseter == null) _dbPreseter = new DatabasePreseter();
                return _dbPreseter;
            }
        }
        private DatabasePreseter(){
            _dbConnect = new DatabaseConnection();
        }
        public DataTable SqlOperation(String sql)
        {
            return _dbConnect.Select(sql);
        }
    }
}
