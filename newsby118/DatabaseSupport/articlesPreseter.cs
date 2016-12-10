using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseSupport;
using System.Data;
using DatabaseSupport.Entity;
namespace DatabaseSupport
{
    public class articlesPreseter
    {
        public static bool InsertArticles(String [] articleMessage)
        {
            int len = articleMessage.Length;
            if (len == 4){

                //  0     1        2            3           4              5                 6           7
                // id   title   summary     [content]   buildtime    classification     pageviews   prasieNumber
                //      0标题                 1内容      2发布时间       3分类         
                String id = articleMessage[2];
                String summary = getSummary(articleMessage[2]);

                String [] msg = new String[9];
                int index = 0;
                msg[index++] = id;
                for(int i=0;i<len;i++){
                    if(i==1){msg[index++] =summary;}
                    msg[index++] = msg[i];
                }
                msg[index++] = "0";msg[index++]="0";//浏览数和点赞数
                String sql = sql = string.Format("insert into article VALUES({0},{1},{2},{3},{4},{5},{6},{7})",msg[0],msg[1],msg[2],msg[3],msg[4],msg[5],msg[6],msg[7]);
                DatabasePreseter.DBPreseter.SqlOperation(sql);

                return true;
            }
            else{
                return false;
            }

        }
        /**
         * 查找所有文章
         **/
        public static DataTable GetAllArticles()
        {
            String sql = "select * from article";
            return DatabasePreseter.DBPreseter.SqlOperation(sql);

        }
        /**
         * 查找指定id的文章
         **/
        public static Article GetArticleById(String id)
        {
            String sql = "select * from article where id='"+id+"'";
            DataTable dt = DatabasePreseter.DBPreseter.SqlOperation(sql);
            Article article = new Article();
            article.setSelf(dt,0);

            return article;

        }
        /**
         * 查找指定分类的文章
         **/
        public static DataTable GetArticleByClassification(int classification)
        {
            String sql = "select * from article where classification=" + classification ;
            return DatabasePreseter.DBPreseter.SqlOperation(sql);
            
        }
        /**
         * 删除指定ID的文章
         **/
        public static bool DelectArticleById(String id)
        {
             String sql = "delete article where id='" + id + "'";
             DatabasePreseter.DBPreseter.SqlOperation(sql);
            return true;
        }
        public static bool DelectArticleById(String [] id_S)
        {
            foreach(String id in id_S){
                DelectArticleById(id);
            }
            return true;
        }

        private static String getSummary(String content)
        {
            String res = content;
            res = res.Replace("<p>", "");
            res = res.Replace("</p>", "");
            res = res.Substring(0,Math.Min(25,res.Length));
            return res;
        }
    }
}
