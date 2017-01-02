using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DatabaseSupport.Entity;
namespace newsby118
{
    public class ArticleMemento
    {
        private Article _article;
    
        public ArticleMemento(Article article)
        {
            this._article = article;
        }
    
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
    }
}
