using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DatabaseSupport;
using DatabaseSupport.Entity;

namespace newsby118.Views
{
    public partial class NewsEditor : System.Web.UI.Page
    {



        String _articleId = null;
        bool isReEdit = false;
        //备忘录的负责人和原发器
        MementoCaretaker mementCaretaker = new MementoCaretaker();
        PresentArticle now_article = new PresentArticle();
        private void bindDropListData()
        {
            DataTable dt = ClassificationPreseter.GetAllClassificatiion();
            ddl_articleType.Items.Clear();
            ddl_articleType.DataSource = dt;
            ddl_articleType.DataTextField = "name";
            //ddl_articleType.DataValueField = "name";
            ddl_articleType.DataBind();
            //ddl_articleType.Items.Insert(0, new ListItem("", ""));//插入空项，此举必须放到数据绑定之后

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                bindDropListData();
            }
            //将原本的数据显示上去
            String articleId = Request.QueryString["articleId"];

            if (articleId != null && articleId != "")
            {
                _articleId = articleId;

                //Response.Write("<script>alert('" + thisArt.Title + "')</script>");

                now_article.state = ArticlesPreseter.GetArticleById(_articleId); 
                //备忘录模式的原发器对象
                mementCaretaker.articleMemento = now_article.SaveArticleMemento();

                //更新
                updateView(now_article.state);
                //updateView(ArticlesPreseter.GetArticleById(_articleId));
                isReEdit = true;
            }
            else
            {
                //新建空对象，防止异常
                now_article.state = new Article();
                //备忘录模式的原发器对象
                mementCaretaker.articleMemento = now_article.SaveArticleMemento();
            }


        }
        //private void updateView(Article article)
        private void updateView(Article dt)
        {

            txb_title.Text = dt.Title;
            compose_textarea.Text = dt.Content;
        }
        private void InsertArticle()
        {
            String title = txb_title.Text;//标题
            String content = compose_textarea.Text; //内容
            //Response.Write(content);
            DateTime date = DateTime.Now; //时间


            Article article = new Article();
            article.Id = date.ToString("yyyyMMddhhmmssfff");            //ID
            article.Title = title;                                      //title
            article.Summary = getSummary(content);                      //summary
            article.Content = content;                                  //content
            article.Buildtime = date.ToString("yyyy-MM-dd hh:mm:ss.fff");   //buildtime

            Response.Write("<script>alert('" + article.Buildtime + "')</script>");
            article.FilesURL = new String[2];                           //文件信息                                                 
            article.Classification = getArticleType();                  //分类
            article.Pageviews = 0;                                      //流浪量
            article.PraiseNumber = 0;                                   //点赞

            ArticlesPreseter.InsertArticles(article);
        }
        private void UpdateArticle()
        {
            String title = txb_title.Text;//标题
            String content = compose_textarea.Text; //内容
            //Response.Write(content);
            DateTime date = DateTime.Now; //时间
            

            Article article = new Article();
            article.Id = _articleId;                                    //ID
            article.Title = title;                                      //title
            article.Summary = getSummary(content);                      //summary
            article.Content = content;                                  //content
            article.Buildtime = date.ToString("yyyy-MM-dd hh:mm:ss.fff");   //buildtime

            Response.Write("<script>alert('" + article.Buildtime + "')</script>");
            article.FilesURL = new String[2];                           //文件信息                                                 
            article.Classification = getArticleType();                  //分类
            article.Pageviews = 0;                                      //流浪量
            article.PraiseNumber = 0;                                   //点赞

            //ArticlesPreseter.UpdataArticleAllMes(article);
        }
        protected void btn_finish_Click(object sender, EventArgs e)
        {
            if (isReEdit)
            {
                Response.Write("<script>alert('" + txb_title.Text.ToString() + "')</script>");
                UpdateArticle();
            }
            else
            {
                InsertArticle();
            }

           
            // Response.Write("<script>alert('" + content + "')</script>");
        }

        /*
         * 暂存
         */
        protected void TempSave_Click(object sender, EventArgs e)
        {
            //存储覆盖备忘录
            mementCaretaker.articleMemento = now_article.SaveArticleMemento();
        }
        /*
         * 撤销
         */
        protected void Revoked_Click(object sender, EventArgs e)
        {
            //取出备忘录
            now_article.RestoreMemento(mementCaretaker.articleMemento);
            //更新
            updateView(now_article.state);
        }
        
        private String getArticleType()
        {
            String classification = ddl_articleType.SelectedValue; //类别
            DataTable classData = ClassificationPreseter.GetAllClassificatiion();
            int count = classData.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if (classification == classData.Rows[i]["name"].ToString())
                {

                    classification = classData.Rows[i]["id"].ToString();
                    break;
                }
            }
            return classification;
        }
        private String getSummary(String content)
        {
            String res = content;

            return ReplaceHtmlTag(res, 25);
        }
        public string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");
            strText = strText.Replace("\r", "").Replace("\n", "");
            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);


            //Response.Write("<script>alert('" + strText + "')</script>");
            return strText;
        }
    }
}