using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using DatabaseSupport.Entity;
using DatabaseSupport;
namespace newsby118.Views
{
    public partial class Test : System.Web.UI.Page
    {
        protected void btn_finish_Click(object sender, EventArgs e)
        {

            //Response.Write("<script>alert('" + thisArt.Title + "')</script>");
            //InsertArticle();
            //String classification = ddl_articleType.SelectedValue; //类别
            //内容
            Response.Write("<script>alert('"+ compose_textarea.Text.ToString()+ "')</script>");
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //article_tmp.Visible = false;
        }
    }
}