using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using DatabaseSupport.Entity;
namespace newsby118
{
    /*
     * 建造者模式：负责人代码
     */
    public class DetailPageContentDirector
    {
        private AbstractContentBuilder _contentBuilder;
        public DetailPageContentDirector()
        {
            _contentBuilder = new DetailBuilder();

        }
        public AbstractContentBuilder contentBuilder
        {
            get
            {
                return _contentBuilder;
            }
            set
            {
                _contentBuilder = value;
            }
        }

        public DetailPageContent Construct(String articleId)
        {
            //_contentBuilder.
            _contentBuilder.BuildArticle(articleId);
            _contentBuilder.BuildComment(articleId);

            return _contentBuilder.GetDetailPageContent();
        }
    }
}
