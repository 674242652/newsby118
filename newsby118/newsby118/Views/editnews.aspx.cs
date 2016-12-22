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
        DataTable classData = null;

        private void bindDropListData()
        {
            DataTable dt = ClassificationPreseter.GetAllClassificatiion();
            ddl_articleType.Items.Clear();
            ddl_articleType.DataSource = dt;
            ddl_articleType.DataTextField = "name";
            //ddl_articleType.DataValueField = "name";
            ddl_articleType.DataBind();
            //ddl_articleType.Items.Insert(0, new ListItem("", ""));//插入空项，此举必须放到数据绑定之后


            classData = ClassificationPreseter.GetAllClassificatiion();
        }
        private void InsertArticle()
        {
            String title = txb_title.Text;//标题
            String content = Server.HtmlEncode(Request.Form["articleContent"]); //内容
            Response.Write(content);
            DateTime date = DateTime.Now; //时间
            String classification = ddl_articleType.SelectedValue; //类别

            
            Article article = new Article();
            article.Id = date.ToShortTimeString();          //ID
            article.Title = title;                          //title
            article.Summary = getSummary(content);          //summary
            article.Content = content;                      //content
            article.Buildtime = date.ToShortTimeString();   //buildtime
            article.FilesURL = new String[2];               //文件信息                                                 
            article.Classification = classification;        //分类
            article.Pageviews = 0;                          //流浪量
            article.PraiseNumber = 0;                       //点赞
            ArticlesPreseter.InsertArticles(article);
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

        protected void btn_finish_Click(object sender, EventArgs e)
        {

            //Response.Write("<script>alert('" + thisArt.Title + "')</script>");
            //InsertArticle();
            //String classification = ddl_articleType.SelectedValue; //类别
            Response.Write("<script>alert('"+getArticleType()+"')</script>");
        }
        private String getArticleType()
        {
            String classification = ddl_articleType.SelectedValue; //类别
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
            res = res.Replace("<p>", "");
            res = res.Replace("</p>", "");
            res = res.Substring(0, Math.Min(25, res.Length));
            return res;
        }
    }
}