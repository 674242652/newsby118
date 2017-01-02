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
    public partial class NewsCategory : System.Web.UI.Page
    {
        private void GridViewBind()
        {
            DataTable dt = ClassificationPreseter.GetAllClassificatiion();
            gdv_classif.DataSource = dt;
            gdv_classif.DataBind();

            for (int i = 0; i < gdv_classif.Rows.Count; i++)
            {
                //为具体类别绑定数据名
                LinkButton lb = (LinkButton)gdv_classif.Rows[i].FindControl("ClassLink");
                lb.Text = dt.Rows[i]["name"].ToString();
            }

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridViewBind();
            }
        }
        /**
         * 跳转到具体的列别管理页
         */
        protected void ClassLink_Click(object sender, EventArgs e)
        {
            //通过点击link类别名，可以选择出单击的是哪一行，从而获得ID
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (gdv_classif.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("NewsList.aspx?classId=" + id);
        }
    }
}