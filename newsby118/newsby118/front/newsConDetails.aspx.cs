using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DatabaseSupport;
/*
 * 新闻列表，从分类进入后的页面
 */
namespace newsby118.front
{
    public partial class newsControl : System.Web.UI.Page
    {

        int _classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //init();
            String classid = Request.QueryString["classId"];
            _classId = (classid == null || classid == "") ? 1 : int.Parse(classid);


            setPageTitle();
            if(!IsPostBack){
                GridViewBind();
            }
        }


        protected void Delect_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (articleList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + s + "')</script>");
           
            articlesPreseter.DelectArticleById(id);
            GridViewBind();
        }
        protected void Edit_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (articleList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("editnews.aspx?articleId="+id);
        }


        private void GridViewBind()
        {
            articleList.DataSource = articlesPreseter.GetArticleByClassification(_classId);
            articleList.DataBind();
        }
        private void setPageTitle()
        {
            DataTable dt = classificationPreseter.GetClassificatiionById(_classId);
            HTMLpageTitle.InnerHtml = dt.Rows[0]["name"].ToString();
        }
    }
}