using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace newsby118
{
    /**
     * 负责人
     */
    public class MementoCaretaker
    {
        private ArticleMemento _articleMemento;
    

        public ArticleMemento articleMemento
        {
            get
            {
                return _articleMemento;
            }
            set
            {
                this._articleMemento = value;
            }
        }
    }
}
