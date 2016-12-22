using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DatabaseSupport;
using DatabaseSupport.Entity;
namespace newsby118.front
{
    public partial class newsDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String articleId = Request.QueryString["articleId"];
            articleId = (articleId == "" || articleId == null) ? "1000" : articleId;
            Article article = ArticlesPreseter.GetArticleById(articleId);
            lab_title.Text = article.Title;
            lab_time.Text = article.Buildtime;
            content.InnerHtml = article.Content;
        }
        /**
         * 提交评论按钮
         */
        protected void btn_sure_Click(object sender, EventArgs e)
        {

            
        }
    }
}