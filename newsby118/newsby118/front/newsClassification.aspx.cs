using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport;
using System.Data;
namespace newsby118.front
{
    public partial class newsPreview : System.Web.UI.Page
    {
        
        private void GridViewBind()
        {
            DataTable dt = classificationPreseter.GetAllClassificatiion();
            gdv_classif.DataSource = dt;
            gdv_classif.DataBind();

            for (int i = 0; i < gdv_classif.Rows.Count; i++)
            {

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
            int row = ((GridViewRow)((LinkButton)sender).NamingContainer).RowIndex;
            String id = (gdv_classif.Rows[row].Cells[0]).Text.ToString().Trim();
            //Response.Write("<script>alert('" + row + "')</script>");
            Response.Redirect("newsConDetails.aspx?classId=" + id);
        }

    }
}