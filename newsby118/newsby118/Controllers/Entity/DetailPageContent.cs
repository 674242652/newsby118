using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DatabaseSupport.Entity;
namespace DatabaseSupport.Entity
{
    /**建造者模式：商品代码
     */
    public class DetailPageContent
    {
        private Article _article;
        private Comment _comment;

        public Article article
        {
            get
            {
                return _article;
            }
            set
            {
                _article = value;
            }
        }

        public Comment comment
        {
            get
            {
                return _comment;
            }
            set
            {
                _comment = value;

            }
        }
    }
}
