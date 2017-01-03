using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace newsby118.Views
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int type = int.Parse(Request.QueryString["type"]);
            if (type == 1)
            {
                pageTitle.InnerHtml = "用户信息修改";
                btn_register.Text = "确认修改";
                lbt_login.Visible = false;
                DataTable dt = (DataTable)(Session["User"]);
                txb_username.Text= dt.Rows[0]["username"].ToString();
            }
        }

        protected void txb_password_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btn_register_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, typeof(Page), "",
                    "if( confirm('申请成功,等待管理员审核....')){location.href='index.aspx'}", true);
            Response.Redirect("login.aspx");
        }
    }
}