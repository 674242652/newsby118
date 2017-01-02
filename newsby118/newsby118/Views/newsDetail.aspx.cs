using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DatabaseSupport;
using DatabaseSupport.Entity;
using System.Collections;
namespace newsby118.front
{
    public partial class newsDetail : System.Web.UI.Page
    {
        String _articleId = "1";
        DataTable comment_dt;
        public int allComment = 0;
        public String [] username;
        public String[] commentTime;
        public String[] contentConnent;

        protected void Page_Load(object sender, EventArgs e)
        {
            

            String articleId = Request.QueryString["articleId"];
            _articleId = (articleId == "" || articleId == null) ? "1" : articleId;
            Article article = ArticlesPreseter.GetArticleById(_articleId);


            lab_title.Text = article.Title;
            lab_time.Text = article.Buildtime;
            content.InnerHtml = article.Content;


            initComment();

            //浏览量+1
            ArticlesPreseter.UpdatePageViews(_articleId);
        }

        private void initComment()
        {
            comment_dt = CommentPreseter.GetCommentsForThisArticle(_articleId);

            ArrayList nameList = new ArrayList();
            ArrayList  timeList = new ArrayList();
            ArrayList contentList = new ArrayList();


            for (int i = 0; i < comment_dt.Rows.Count; i++)
            {
                nameList.Add(comment_dt.Rows[i]["username"].ToString());
                timeList.Add(comment_dt.Rows[i]["buildTime"].ToString());
                contentList.Add(comment_dt.Rows[i]["content"].ToString());
            }
            username = (string[])nameList.ToArray(typeof(string));
            commentTime = (string[])timeList.ToArray(typeof(string)); ;
            contentConnent = (string[])contentList.ToArray(typeof(string));

            allComment = username.Length;


        }

        /**
         * 提交评论按钮
         */
        protected void btn_sure_Click(object sender, EventArgs e)
        {

            DataTable dt = (DataTable)Session["User"];
            try
            {
                if (dt.Rows.Count > 0)
                {
                    Response.Write("<script>alert('" + dt.Rows[0]["username"] + "')</script>");
                    DateTime now = DateTime.Now;
                    String commentId = now.ToString("yyyyMMddhhMMssFFF");
                    String commentContent = txb_comment.Text.ToString();
                    String commentUserId = dt.Rows[0]["id"].ToString();
                    String commentArticleId = _articleId;
                    String commentTime = now.ToString("yyyy-MM-dd hh:mm:ss.fff");

                    CommentPreseter.InsertComment(commentId, commentContent, commentUserId, commentArticleId, commentTime);
                }
            }
            catch (NullReferenceException ee)
            {
                //Response.Write("<script>alert('" + "请先登录" + "')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "",
                    "if(confirm('您还未登录，前往登录?')){location.href='login.aspx'}else{location.href='newsDetail.aspx'}", true);
            }
           
            
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            String keyword = txb_search.Text.ToString();
            Response.Redirect("SearchResult.aspx?keyword="+keyword);

        }
    }
}