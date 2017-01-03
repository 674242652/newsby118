using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DatabaseSupport.Entity;
namespace newsby118
{
    public abstract class AbstractContentBuilder
    {
        private DetailPageContent _detailPageContent = new DetailPageContent();

        public DetailPageContent detailPageContent
        {
            get
            {
                return _detailPageContent;
            }
            set
            {
                _detailPageContent = value;
            }
        }

        /// <summary>
        /// 抽象方法
        /// </summary>
        public abstract Article BuildArticle(String articleId);

        /// <summary>
        /// 抽象方法
        /// </summary>
        public abstract Comment BuildComment(String articleId);

        public DetailPageContent GetDetailPageContent()
        {
            return _detailPageContent;
        }
    }
}
