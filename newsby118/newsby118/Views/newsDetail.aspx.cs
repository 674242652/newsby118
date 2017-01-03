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
using newsby118;

namespace newsby118.front

    public partial class newsDetail : System.Web.UI.Page
    {
        String _articleId = "1";
        //DataTable comment_dt;
        public int allComment = 0;
        public String [] username;
        public String [] commentTime;
        public String [] contentConnent;
        
        DetailPageContentDirector directed = new DetailPageContentDirector();
        DetailPageContent pagetContent = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            String articleId = Request.QueryString["articleId"];
            _articleId = (articleId == "" || articleId == null) ? "1" : articleId;
            pagetContent = directed.Construct(_articleId);
            //Article article = ArticlesPreseter.GetArticleById(_articleId);
            initPageContent();
            //initComment();
            ArticlesPreseter.UpdatePageViews(_articleId); //浏览量+1
        }
        private void initPageContent()
        {
            //初始化文章内容
            lab_title.Text = pagetContent.article.Title;
            lab_time.Text = pagetContent.article.Buildtime;
            content.InnerHtml = pagetContent.article.Content;
            //初始化评论
            ArrayList nameList = pagetContent.comment.nameList;
            ArrayList timeList = pagetContent.comment.timeList;
            ArrayList contentList = pagetContent.comment.contentList;
            username = (string[])nameList.ToArray(typeof(string));
            commentTime = (string[])timeList.ToArray(typeof(string)); ;
            contentConnent = (string[])contentList.ToArray(typeof(string));

            allComment = username.Length;
        }
        /*
        private void initComment()
        {
            //comment_dt = CommentPreseter.GetComments_DT_ForThisArticle(_articleId);

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
         */

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
                    //Response.Write("<script>alert('" + dt.Rows[0]["username"] + "')</script>");
                    DateTime now = DateTime.Now;
                    String commentId = now.ToString("yyyyMMddhhMMssFFF");
                    String commentContent = txb_comment.Text.ToString();
                    String commentUserId = dt.Rows[0]["id"].ToString();
                    String commentArticleId = _articleId;
                    String commentTime = now.ToString("yyyy-MM-dd hh:mm:ss.fff");
                    String commentusnername = dt.Rows[0]["username"].ToString();
                    CommentPreseter.InsertComment(commentId, commentContent, commentUserId, commentArticleId, commentTime, commentusnername);
                }
            }
            catch (NullReferenceException ee)
            {
                //Response.Write("<script>alert('" + "请先登录" + "')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "",
                    "if(confirm('您还未登录，前往登录?')){location.href='login.aspx'}else{location.href='newsDetail.aspx?articleId="+_articleId+"'}", true);
            }
           
            
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            String keyword = txb_search.Text.ToString();
            Response.Redirect("SearchResult.aspx?keyword="+keyword);

        }
    }
}