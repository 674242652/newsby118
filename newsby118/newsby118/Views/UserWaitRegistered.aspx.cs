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
    public partial class UserWaitRegistered : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = UserPreseter.GetAllWaitRegisteredUser();

            setPageTitle();
            if (!IsPostBack)
            {
                GridViewBind(dt);
            }
        }


        //删除某条新闻的监听
        protected void Delect_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (userList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + s + "')</script>");
            ArticlesPreseter.DelectArticleById(id);
            //需要根据类别确定
            DataTable dt = UserPreseter.GetAllWaitRegisteredUser();
            GridViewBind(dt);

        }
        //编辑某条新闻：点击进入新闻的编辑页
        protected void Save_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (userList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("NewsEditor.aspx?articleId=" + id);
        }


        private void GridViewBind(DataTable dt)
        {
            userList.DataSource = dt;
            userList.DataBind();
        }
        private void setPageTitle()
        {
            HTMLpageTitle.InnerHtml = "待审核注册用户列表";

        }

        protected void titleLink_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (userList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("newsDetail.aspx?articleId=" + id);
        }
    }
}