using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseSupport;

namespace WebApplication4.front
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
            String usr = txt_username.Text;
            String pwd = txt_password.Text;

            LoginPreseter lp = new LoginPreseter();
            bool res = lp.Login(usr,pwd);

            if (res){
                Response.Redirect("newsClassification.aspx");
            }
            else
            {
                Response.Write("<script>alert('用户名或密码错误')</script>");
            }
        }
    }
}