using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport.Entity;
using DatabaseSupport;
using System.Collections;  
  
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
            String ss = Request.QueryString["page"];
            SetArticleMsg();


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

    }
}