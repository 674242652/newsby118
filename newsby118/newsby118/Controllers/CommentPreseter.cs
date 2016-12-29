using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace DatabaseSupport
{
    public class CommentPreseter
    {



        public static bool InsertComment(String id,String content,String userId,String articleId ,String buildTime)
        {
            String sql = string.Format("insert into comment VALUES('{0}','{1}','{2}','{3}','{4}')", id, content, userId,articleId, buildTime);
            DatabasePreseter.DBPreseter.SqlOperation(sql);

            return true;
        }

        public static DataTable GetAllComments()
        {
            String sql = "select * from comment";
            return DatabasePreseter.DBPreseter.SqlOperation(sql); ;
        }

        public static DataTable GetCommentsForThisArticle(String articleId)
        {
            String sql= "select * from comment where articleId = '" + articleId +"'";
            return DatabasePreseter.DBPreseter.SqlOperation(sql); ;
        }

    }
}