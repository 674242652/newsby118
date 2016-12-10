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
            DataTable dt = classificationPreseter.GetAllClassificatiion();
            ddl_articleType.Items.Clear();
            ddl_articleType.DataSource = dt;
            ddl_articleType.DataTextField = "name";
            //ddl_articleType.DataValueField = "name";
            ddl_articleType.DataBind();
            //ddl_articleType.Items.Insert(0, new ListItem("", ""));//插入空项，此举必须放到数据绑定之后
        }
        private void InsertArticle()
        {
            String title = txb_title.Text;//标题
            String content = Server.HtmlEncode(Request.Form["articleContent"]); //内容
            Response.Write(content);
            DateTime date = DateTime.Now; //时间
            String classification = ddl_articleType.SelectedValue; //类别

            //  0     1        2            3           4              5                 6           7
            // id   title   summary     [content]   buildtime    classification     pageviews   prasieNumber
            //      0标题                 1内容      2发布时间       3分类           

            String[] msg = new String[4];
            msg[0] = title;
            msg[1] = content;
            msg[2] = date.ToString();
            msg[3] = classification;


            articlesPreseter.InsertArticles(msg);
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
                

                Article thisArt = articlesPreseter.GetArticleById(_articleId);
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
            //Response.Write("<script>alert('"+classification+"')</script>");
        }
    }
}