using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Data;
namespace DatabaseSupport
{
    public class RealUser :AbstractUser
    {
        DataTable _userData;

        public DataTable UserData
        {
            get { return _userData; }
            set { _userData = value; }
        }

        public void EnterManegerment()
        {
            HttpContext.Current.Response.Redirect("../Views/NewsList.aspx");
        }
        public RealUser(DataTable dt)
        {
            this._userData = dt;
        }
    }
}
