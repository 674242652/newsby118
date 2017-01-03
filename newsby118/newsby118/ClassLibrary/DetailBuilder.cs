using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
using DatabaseSupport;
using DatabaseSupport.Entity;
namespace newsby118
{
    public class DetailBuilder : AbstractContentBuilder
    {
        public override DatabaseSupport.Entity.Article BuildArticle(String articleId)
        {

            Article article = ArticlesPreseter.GetArticleById(articleId);
            //建造article属性
            detailPageContent.article = article;
            
            return article;
        }

        public override DatabaseSupport.Entity.Comment BuildComment(String articleId)
        {
            Comment c = CommentPreseter.GetCommentsForThisArticle(articleId);
            detailPageContent.comment = c;
            return c;
        }
    }
}
