using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
namespace newsby118.Controllers.Entity
{
    public class User
    {
        private String _userID;//用户ID
        public String UserID
        {
            get { return _userID; }
            set { _userID = value; }
        }


        private String _email; //email

        public String Email
        {
            get { return _email; }
            set { _email = value; }
        }

        private int _category;//用户类别，管理员、普通用户等等

        public int Category
        {
            get { return _category; }
            set { _category = value; }
        }
        private String _username;

        public String Username
        {
            get { return _username; }
            set { _username = value; }
        }
        private String _password;

        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public User()
        {
            _userID = String.Empty;
            _email = String.Empty;
            _username = String.Empty;
            _password = String.Empty;
            _category = -1;
        }
        public User(DataTable dt,int r)
        {
            _userID = dt.Rows[r]["id"].ToString();
            _email = dt.Rows[r]["email"].ToString();
            _username = dt.Rows[r]["username"].ToString();
            _password = dt.Rows[r]["password"].ToString();
            _category = (int)dt.Rows[r]["category"];


        }
        public void SetUser(User user){
            _userID = user.UserID;
            _email = user.Email;
            _username = user.Username;
            _password = user.Password;
            _category = user.Category;
        }
    }
}