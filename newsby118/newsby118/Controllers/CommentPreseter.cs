using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using DatabaseSupport.Entity;
namespace DatabaseSupport
{
    public class CommentPreseter
    {



        public static bool InsertComment(String id,String content,String userId,String articleId ,String buildTime ,String username)
        {
            String sql = string.Format("insert into comment VALUES('{0}','{1}','{2}','{3}','{4}' , '{5}')", id, content, userId,articleId, buildTime,username);
            DatabasePreseter.DBPreseter.SqlOperation(sql);

            return true;
        } 

        public static DataTable GetAllComments()
        {
            String sql = "select * from comment";
            return DatabasePreseter.DBPreseter.SqlOperation(sql); ;
        }

        public static DataTable GetComments_DT_ForThisArticle(String articleId)
        {
            String sql = string.Format("select * from comment where articleId = '{0}'",articleId);
            return DatabasePreseter.DBPreseter.SqlOperation(sql);
        }

        public static Comment GetCommentsForThisArticle(String articleId)
        {
            String sql = string.Format("select * from comment where articleId = '{0}'", articleId);
            Comment c;
            try
            {
                c = new Comment(DatabasePreseter.DBPreseter.SqlOperation(sql));
            }
            catch
            {
                c = new Comment();
            }
            return c;


            //return null;
        }



        public static DataTable DelectCommentById(String Id)
        {
            String sql = string.Format("delete comment where id = '{0}'",Id);
            return DatabasePreseter.DBPreseter.SqlOperation(sql); ;
        }
    }
}