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
    public class ArticlesPreseter
    {
        public static bool InsertArticles(Article article)
        {

                //  0     1        2            3           4              5                 6           7
                // id   title   summary     [content]   buildtime    classification     pageviews   prasieNumber
                //      0标题                 1内容      2发布时间       3分类         


                String[] msg = article.FieldsToString();


                String sql = sql = string.Format("insert into article VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8})", msg[0], msg[1], msg[2], msg[3], msg[4], msg[5], msg[6], msg[7], msg[8]);
                DatabasePreseter.DBPreseter.SqlOperation(sql);

                return true;

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
        public static void UpdataArticleAllMes(Article article)
        {
            String[] msg = article.FieldsToString();
            String sql = string.Format("update article set title='{0}',summary='{1}',content='{2}',buildtime='{3}',filesURL='{4}',classification={5} where id = '{6}'", msg[1], msg[2], msg[3], msg[4], msg[5], msg[6],msg[0]);
            DatabasePreseter.DBPreseter.SqlOperation(sql);
        }
        public static void UpdatePageViews(String id)
        {
            String sql = "update article set pageviews=pageviews+1 where id = '" + id + "'";
            DatabasePreseter.DBPreseter.SqlOperation(sql);
        }


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

        
    }
}
