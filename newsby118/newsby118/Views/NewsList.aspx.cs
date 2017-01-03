using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport;
using DatabaseSupport.Entity;
using System.Data;
namespace newsby118.Views
{
    public partial class NewsList : System.Web.UI.Page
    {
        int _classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //init();
            String classid = Request.QueryString["classId"];
            //如果没有指定新闻类别，那么就把所有的新闻都查出来
            //如果有指定的类型，那么就查当前的类型
            DataTable dt = null;
            if (classid == null || classid == "")
            {
                dt = ArticlesPreseter.GetAllArticles();
                _classId = -1;

                DataTable newest_dt = dt.Copy();
                DataView newest_dv = newest_dt.DefaultView;
                newest_dv.Sort = "id DESC";     //按id字段的逆序排序
                //dv.Sort = "id ASC";  //按正排序
                newest_dt = newest_dv.ToTable();
                dt = newest_dt;
            }
            else
            {
                _classId = int.Parse(classid);
                dt = ArticlesPreseter.GetArticleByClassification(_classId).Copy();
                DataTable newest_dt = dt.Copy();
                DataView newest_dv = newest_dt.DefaultView;
                newest_dv.Sort = "id DESC";     //按id字段的逆序排序
                //dv.Sort = "id ASC";  //按正排序
                newest_dt = newest_dv.ToTable();
                dt = newest_dt;
            }


            setPageTitle();//开头出列出新闻的类别，如果是全部新闻，那就显示“所有新闻”
            if (!IsPostBack){
                GridViewBind(dt);
            }
        }

       
         //删除某条新闻的监听
        protected void Delect_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (articleList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + s + "')</script>");
            ArticlesPreseter.DelectArticleById(id);
            //需要根据类别确定
            DataTable dt = _classId == -1 ? ArticlesPreseter.GetAllArticles() : ArticlesPreseter.GetArticleByClassification(_classId);
            GridViewBind(dt);

        }
        //编辑某条新闻：点击进入新闻的编辑页
        protected void Edit_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (articleList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("NewsEditor.aspx?articleId=" + id);
        }


        private void GridViewBind(DataTable dt)
        {
            articleList.DataSource = dt;
            articleList.DataBind();
        }
        private void setPageTitle()
        {
            String pageTitle = "所有新闻";
            if(_classId != -1){
                DataTable dt = ClassificationPreseter.GetClassificatiionById(_classId);
                pageTitle = dt.Rows[0]["name"].ToString();
            }
            HTMLpageTitle.InnerHtml = pageTitle;
            
        }

        protected void titleLink_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (articleList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("newsDetail.aspx?articleId=" + id);
        }
    }
}