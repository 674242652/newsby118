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
        private String[] filesURL;
        private String classification;
        
        int praiseNumber;
        int pageviews;

        private String editor;//作者需要用article-user中查出来，由于用的不频繁所以构建的时候不准备每个都构建，需要用的时候查询一下
        public Article(DataTable dt, int rowid){
            setSelf(dt, rowid);
        }
        public Article() {
            
            id = String.Empty;
            title = String.Empty;
            summary = String.Empty;
            content = String.Empty;
            buildtime = String.Empty;
            filesURL = new String[]{""};
            classification = string.Empty;
            PraiseNumber = 0;
            Pageviews = 0;
        }
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
        public String[] FieldsToString()
        {
            String [] fields = new String[9];

            fields[0] = id;
            fields[1] =title;
            fields[2] =summary;
            fields[3] =content;
            fields[4] =buildtime;

            StringBuilder fiurl = new StringBuilder();
            int len = filesURL.Length;
            for (int i = 0; i < len; i++)
            {
                fiurl.Append(filesURL[i]);
                if (i != len - 1)
                {
                    fiurl.Append('&');
                }
            }
            fields[5] = fiurl.ToString();
            fields[6] = classification;
        
            fields[7] =praiseNumber.ToString();
            fields[8] =pageviews.ToString();

            return fields;
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
