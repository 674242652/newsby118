using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DatabaseSupport.Entity;
namespace newsby118
{
    /*
     * 现在的状态
     */
    public class PresentArticle
    {
        private Article _state;

        public Article state
        {
            get
            {
                return _state;
            }
            set
            {
                this._state = value;
            }
        }
        public ArticleMemento SaveArticleMemento()
        {
            return new ArticleMemento(state);
        }

        public Article RestoreMemento(ArticleMemento memento)
        {
            this._state = memento.article;
            return state;
        }
    }
}
