using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Collections;

namespace DatabaseSupport.Entity
{
    public class Comment
    {
        private string _id = String.Empty;

        private string _content = String.Empty;

        private string _userId = String.Empty;

        private string _articleId = String.Empty;

        private string _buildtime = String.Empty;

        public ArrayList nameList = new ArrayList();
        public ArrayList timeList = new ArrayList();
        public ArrayList contentList = new ArrayList();

        private DataTable comment_dt = new DataTable();
		public string id
		{
			get{return this._id;}
			set{}
		}
		
		public string content
		{
			get{return this._content;}
			set{}
		}
		
		public string userId
		{
			get{return this._userId;}
			set{}
		}
		public string articleId
		{
			get{return this._articleId;}
			set{}
		}
        public void buildList(){}
        public Comment() { ;}
        public Comment(DataTable dt){
            this._id = dt.Rows[0]["id"].ToString();
            this._articleId = dt.Rows[0]["articleId"].ToString();
            this._buildtime = dt.Rows[0]["buildtime"].ToString();
            this._content = dt.Rows[0]["content"].ToString();
            this._userId = dt.Rows[0]["userId"].ToString();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                nameList.Add(dt.Rows[i]["username"].ToString());
                timeList.Add(dt.Rows[i]["buildTime"].ToString());
                contentList.Add(dt.Rows[i]["content"].ToString());
            }

            comment_dt = dt;
        }
    }
}