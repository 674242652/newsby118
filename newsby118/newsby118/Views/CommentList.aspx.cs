using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport;
using System.Data;
namespace newsby118.Views
{
    public partial class CommentList : System.Web.UI.Page
    {
        int _classId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            
            if (!IsPostBack)
            {
                DataTable dt = CommentPreseter.GetAllComments();
                GridViewBind(dt);
            }
        }


        //删除某条新闻的监听
        protected void Delect_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (articleList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + s + "')</script>");
            CommentPreseter.DelectCommentById(id);
            //需要根据类别确定
            DataTable dt = CommentPreseter.GetAllComments();
            GridViewBind(dt);

        }

        private void GridViewBind(DataTable dt)
        {
            articleList.DataSource = dt;
            articleList.DataBind();
        }
        private void setPageTitle()
        {
            String pageTitle = "所有评论";
            HTMLpageTitle.InnerHtml = pageTitle;

        }
    }
}