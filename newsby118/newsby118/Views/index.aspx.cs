using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport.Entity;
using DatabaseSupport;
using System.Data;
namespace WebApplication4.front
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewsBind();
            }
        }

        private void GridViewsBind(){

            DataTable dt = ArticlesPreseter.GetAllArticles();

            GridViewBindDetial(gdv_newsList,dt);    //普通新闻列表

            DataTable newest_dt = dt.Copy();
            DataView newest_dv = newest_dt.DefaultView;
            newest_dv.Sort = "id ASC";     //按id字段的正序排序
            //dv.Sort = "id DESC";  //按逆序排序
            newest_dt = newest_dv.ToTable();
            GridViewBindDetial(gdv_newestNewsList, newest_dt);//最新新闻列表


            DataTable hot_dt = dt.Copy();
            DataView hot_dv = hot_dt.DefaultView;
            hot_dv.Sort = "pageviews ASC";     //按id字段的正序排序
            //dv.Sort = "id DESC";  //按逆序排序
            hot_dt = hot_dv.ToTable();
            GridViewBindDetial(gdv_hotNewsList, hot_dt);//最新新闻列表


        }
        //这里需要深克隆
        private void GridViewBindDetial(GridView gdv,DataTable dt)
        {

            gdv.DataSource = dt;
            gdv.DataBind();

            for (int i = 0; i < gdv.Rows.Count; i++)
            {
                //为具体类别绑定数据名
                LinkButton lb = (LinkButton)gdv.Rows[i].FindControl("titleLink");
                lb.Text = dt.Rows[i]["title"].ToString();
            }
            //影藏第一列，但是我需要从这里获取ID

            gdv.Columns[0].Visible = false;
        }
        protected void titleLink_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (gdv_newsList.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + id + "')</script>");
            Response.Redirect("newsDetail.aspx?articleId=" + id);
        }

    }
}