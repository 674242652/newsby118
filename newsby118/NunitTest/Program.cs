using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseSupport;
using System.Data;
namespace NunitTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DataTable dt = DatabasePreseter.DBPreseter.SqlOperation("select * from [user]");
            Console.WriteLine(dt.Rows[0]["username"]);
        }
    }
}
