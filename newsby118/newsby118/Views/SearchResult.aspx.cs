using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport.Entity;
using DatabaseSupport;
using System.Collections;
using System.Data;
namespace WebApplication4.front
{
    public partial class SearchResult : System.Web.UI.Page
    {
        
        public int onepage = 10;
        public int allnumber = 0;//所有的长度
        public String[] title = null;
        public String[] summary = null;
        public String[] articleId = null;


        String keyword = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            dropDownListBind();
            //String ss = Request.QueryString["page"];
            keyword = Request.QueryString["keyword"];
            SetArticleMsg();


        }
        private void dropDownListBind()
        {
            DataTable dt = ClassificationPreseter.GetAllClassificatiion();
            ddl_newscategory.Items.Clear();
            ddl_newscategory.DataSource = dt;
            ddl_newscategory.DataTextField = "name";
            //ddl_newscategory.DataValueField = "name";
            ddl_newscategory.DataBind();
            ddl_newscategory.Items.Insert(0, new ListItem("所有类别", ""));//插入空项，此举必须放到数据绑定之后
        }
        private void SetArticleMsg()
        {
            List<Article> list = SearchPreseter.SearchArticleByKeyword(keyword);
            ArrayList title_list = new ArrayList();
            ArrayList summary_list = new ArrayList();
            ArrayList id_list = new ArrayList();
            foreach (Article a in list)
            {
                title_list.Add(a.Title);
                summary_list.Add(a.Summary);
                id_list.Add(a.Id);
            }
            title = (string[])title_list.ToArray(typeof(string));
            summary = (string[])summary_list.ToArray(typeof(string)); ;
            articleId = (string[])id_list.ToArray(typeof(string));
            allnumber = title.Length;
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            String key = txt_search.Text.ToString();
            Response.Redirect("SearchResult.aspx?keyword=" + key);
        }

    }
}