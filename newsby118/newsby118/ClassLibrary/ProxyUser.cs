using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
namespace DatabaseSupport
{
    public class ProxyUser :AbstractUser 
    {
        RealUser _realUser;
        int level = -1;
        public RealUser RealUser
        {
            get
            {
                return _realUser;
            }
            set
            {
                _realUser = value;
                SetLevel();
            }
        }
        public ProxyUser(RealUser RealUser)
        {
            _realUser = RealUser;
            SetLevel();
           
        }
    
        public void EnterManegerment()
        {
            if (level == 0){
               _realUser.EnterManegerment();
           }
           else{

               HttpContext.Current.
                   Response.Write("<script>alert('您的权限不够，请重新登录')</script>");
           }
        }

        private void SetLevel(){
             try{
                level = (int)((_realUser.UserData).Rows[0]["category"]);
            }
            catch{
                ///...
            }
        }
    }
}
