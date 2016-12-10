using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DatabaseSupport.Entity
{
    public class Article
    {
        private String id;
        private String title;
        private String summary;
        private String content;
        private String buildtime;
        private String classification;
        private String[] filesURL;
        int praiseNumber;
        int pageviews;
        public Article(DataTable dt, int rowid){
            setSelf(dt, rowid);
        }
        public Article() { ;}
        public void setSelf(DataTable dt,int rowid)
        {
            DataRowCollection r = dt.Rows;
            id = r[rowid]["id"].ToString();
            title = r[rowid]["title"].ToString();
            summary = r[rowid]["summary"].ToString();
            content = r[rowid]["content"].ToString();
            buildtime = r[rowid]["buildtime"].ToString();
            classification = r[rowid]["classification"].ToString();
            String furl = r[rowid]["filesURL"].ToString();
            pageviews = int.Parse(r[rowid]["pageviews"].ToString());
            praiseNumber = int.Parse(r[rowid]["praiseNumber"].ToString());
            filesURL = furl.Split('&');//用&分割多个文件
        }


        public static bool operator ==(Article a, Article b)
        {
            return a.id == b.id;
        }

        public static bool operator !=(Article a, Article b)
        {
            return !(a == b);
        }


        public String Id
        {
            get { return id; }
            set { id = value; }
        }
        

        public String Title
        {
            get { return title; }
            set { title = value; }
        }
       

        public String Summary
        {
            get { return summary; }
            set { summary = value; }
        }
        

        public String Content
        {
            get { return content; }
            set { content = value; }
        }
        

        public String Buildtime
        {
            get { return buildtime; }
            set { buildtime = value; }
        }
        

        public String Classification
        {
            get { return classification; }
            set { classification = value; }
        }
        

        public String[] FilesURL
        {
            get { return filesURL; }
            set { filesURL = value; }
        }
        

        public int Pageviews
        {
            get { return pageviews; }
            set { pageviews = value; }
        }
        

        public int PraiseNumber
        {
            get { return praiseNumber; }
            set { praiseNumber = value; }
        }

        
    }
}
