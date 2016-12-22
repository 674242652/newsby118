using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatabaseSupport;
using DatabaseSupport.Entity;
using System.Collections;
namespace DatabaseSupport
{
    public class SearchPreseter
    {

        public static List<Article> SearchArticleByKeyword(String keyword)
        {
            List<Article> aList = new List<Article>();
            String[] key = new String[4];
            key[0] = keyword; 
            key[1] = key + "%";
            key[2] = "%"+keyword; 
            key[3] = "%"+keyword + "%";

            for (int i = 0; i < 4; i++)
            {
                String sql = String.Empty;
                if (i == 0) { 
                    sql = "select * from article where title='" + key[i] +"'";
                }
                else
                {
                    sql = "select * from article where title like'" + key[i] + "'";
                }
                DataTable dt = DatabasePreseter.DBPreseter.SqlOperation(sql);
                addToList(dt, aList);
                
            }

            return aList;
        }

        private static void addToList(DataTable dt, List<Article> aList)
        {
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++){
                bool flag = true;
                Article n = new  Article(dt,i);
               
                foreach (Article a in aList){
                    if (a.Id == n.Id){
                        flag = false; break;
                    }
                }
                if(flag){
                    aList.Add(n);
                }
            }
        }
    }
}
