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
        bool isLog = false;
        ProxyUser proxyUser;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)Session["User"];
            btn_logout.Visible = false;
            try
            {
                if (dt.Rows.Count > 0)
                {
                    btn_login.Text = "新闻管理";
                    btn_registered.Text = dt.Rows[0]["username"].ToString();
                    isLog = true;
                    btn_logout.Visible = true;
                }
            }
            catch
            {
                
            }
            proxyUser = new ProxyUser(new RealUser(dt));

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
            newest_dv.Sort = "id DESC";     //按id字段的正序排序
            //dv.Sort = "id DESC";  //按逆序排序
            newest_dt = newest_dv.ToTable();
            GridViewBindDetial(gdv_newestNewsList, newest_dt);//最新新闻列表


            DataTable hot_dt = dt.Copy();
            DataView hot_dv = hot_dt.DefaultView;
            hot_dv.Sort = "pageviews DESC";     //按id字段的正序排序
            //dv.Sort = "id DESC";  //按逆序排序
            hot_dt = hot_dv.ToTable();
            GridViewBindDetial(gdv_hotNewsList, hot_dt);//最新新闻列表


        }
        //这里需要深克隆
        private void GridViewBindDetial(GridView gdv,DataTable dt)
        {
            gdv.DataSource = dt;
            gdv.DataBind();
        }

        /*---------------------------表一--------------------------*/
        protected void gdv_newsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
           

            try
            {
                gdv_newsList.PageIndex = e.NewPageIndex;
                GridViewBindDetial(gdv_newsList, ArticlesPreseter.GetAllArticles());

                TextBox tb = (TextBox)gdv_newsList.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gdv_newsList.PageIndex + 1).ToString();
            }
            catch
            {

            }
        }

        protected void gdv_newsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)gdv_newsList.BottomPagerRow.FindControl("inPageNum");

                // Response.Write("<script>alert('" + tb.Text + "')</script>");

                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                gdv_newsList_PageIndexChanging(null, ea);
            }
            catch
            {

            }
        }
        /*---------------------------表二--------------------------*/

        protected void gdv_newestNewsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            try
            {
                gdv_newestNewsList.PageIndex = e.NewPageIndex;
                DataTable newest_dt = ArticlesPreseter.GetAllArticles();
                DataView newest_dv = newest_dt.DefaultView;
                newest_dv.Sort = "id ASC";     //按id字段的正序排序
                //dv.Sort = "id DESC";  //按逆序排序
                newest_dt = newest_dv.ToTable();
                GridViewBindDetial(gdv_newestNewsList, newest_dt);//最新新闻列表

                TextBox tb = (TextBox)gdv_newestNewsList.BottomPagerRow.FindControl("inPageNum");
                tb.Text = (gdv_newestNewsList.PageIndex + 1).ToString();
            }
            catch
            {

            }




            /*
            gdv_newestNewsList.PageIndex = e.NewPageIndex;
            DataTable newest_dt = ArticlesPreseter.GetAllArticles();
            DataView newest_dv = newest_dt.DefaultView;
            newest_dv.Sort = "id ASC";     //按id字段的正序排序
            //dv.Sort = "id DESC";  //按逆序排序
            newest_dt = newest_dv.ToTable();
            GridViewBindDetial(gdv_newestNewsList, newest_dt);//最新新闻列表
             */
        }
        protected void gdv_newestNewsList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                TextBox tb = (TextBox)gdv_newestNewsList.BottomPagerRow.FindControl("inPageNum");

               // Response.Write("<script>alert('" + tb.Text + "')</script>");

                int num = Int32.Parse(tb.Text);
                GridViewPageEventArgs ea = new GridViewPageEventArgs(num - 1);
                gdv_newestNewsList_PageIndexChanging(null, ea);
            }
            catch
            {

            }
        }
        protected void gdv_hotNewsList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            
            gdv_hotNewsList.PageIndex = e.NewPageIndex;


            DataTable hot_dt = ArticlesPreseter.GetAllArticles();
            DataView hot_dv = hot_dt.DefaultView;
            hot_dv.Sort = "pageviews ASC";     //按id字段的正序排序
            //dv.Sort = "id DESC";  //按逆序排序
            hot_dt = hot_dv.ToTable();
            GridViewBindDetial(gdv_hotNewsList, hot_dt);//最新新闻列表
        }

        protected void btn_search_Click(object sender, EventArgs e)
        {
            String keyword = txb_search.Text.ToString();
            Response.Redirect("SearchResult.aspx?keyword=" + keyword);
        }

        protected void btn_registered_Click(object sender, EventArgs e)
        {
            if (isLog)
            {
                
               Response.Redirect("Register.aspx?type=1");
            }
            else
            {
                Response.Redirect("Register.aspx?type=0");
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            if(isLog){
                proxyUser.EnterManegerment();
            }else{
                Response.Redirect("login.aspx");
            }
        }

        protected void btn_logout_Click(object sender, EventArgs e)
        {
            btn_login.Text = "登录";
           
            btn_registered.Text = "注册";
            isLog = false;

            Session["User"] = null;
            btn_logout.Visible = false;
        }

    }
}