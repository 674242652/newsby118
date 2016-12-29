using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DatabaseSupport;
using DatabaseSupport.Entity;
namespace WebApplication4.front
{
    public partial class editnews : System.Web.UI.Page
    {
        String _articleId = null;
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
                

                Article thisArt = ArticlesPreseter.GetArticleById(_articleId);
                //Response.Write("<script>alert('" + thisArt.Title + "')</script>");


                txb_title.Text = thisArt.Title;
                compose_textarea.InnerHtml = thisArt.Content;
            }
            
            
        }
        private void InsertArticle()
        {
            String title = txb_title.Text;//标题
            String content = compose_textarea.Value; //内容
            //Response.Write(content);
            DateTime date = DateTime.Now; //时间
            

            Article article = new Article();
            article.Id = date.ToString("yyyyMMddhhmmssfff");               //ID
            article.Title = title;                                      //title
            article.Summary = getSummary(content);                      //summary
            article.Content = content;                                  //content
            article.Buildtime = date.ToString("yyyy-MM-dd hh:mm:ss.fff");   //buildtime
            article.FilesURL = new String[2];                           //文件信息                                                 
            article.Classification = getArticleType();                  //分类
            article.Pageviews = 0;                                      //流浪量
            article.PraiseNumber = 0;                                   //点赞
           
            ArticlesPreseter.InsertArticles(article);
        }
        protected void btn_finish_Click(object sender, EventArgs e)
        {

            //Response.Write("<script>alert('" + thisArt.Title + "')</script>");
            InsertArticle();
            //String classification = ddl_articleType.SelectedValue; //类别
            //内容
           // Response.Write("<script>alert('" + content + "')</script>");
        }
        private String getArticleType()
        {
            String classification = ddl_articleType.SelectedValue; //类别
            DataTable classData = ClassificationPreseter.GetAllClassificatiion();
            int count = classData.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                if(classification == classData.Rows[i]["name"].ToString()){

                    classification = classData.Rows[i]["id"].ToString();
                    break;
                }
            }
            return classification;
        } 
        private String getSummary(String content)
        {
            String res = content;

            return ReplaceHtmlTag(res,25);
        }
        public  string ReplaceHtmlTag(string html, int length = 0)
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