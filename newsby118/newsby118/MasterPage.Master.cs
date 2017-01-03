using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace newsby118
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {

        protected void Page_Init(object sender, EventArgs e)
        {
            //checkLogin();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        private void checkLogin()
        {
            DataTable dt = (DataTable)Session["User"];
            try
            {
                if (dt.Rows.Count > 0)
                {
                    int userCategory = (int)dt.Rows[0]["category"];
                    if (userCategory >= 1)//权限不够
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "",
                    "if(confirm('抱歉，您没有权限，重新登录?')){location.href='login.aspx'}else{location.href='index.aspx'}", true);
                    }
                }
            }
            catch (NullReferenceException ee)
            {
                //Response.Write("<script>alert('" + "请先登录" + "')</script>");
                ScriptManager.RegisterStartupScript(this, typeof(Page), "",
                    "if(confirm('您还未登录，前往登录?')){location.href='login.aspx'}else{location.href='index.aspx'}", true);
            }
        }

        protected void lbn_logout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("index.aspx");
        }

    }
}