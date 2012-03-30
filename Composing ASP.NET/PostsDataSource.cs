using System.Collections.Generic;
using System.Web;
using Composing_ASP.NET_Presentation_Logic;
using Ninject;

namespace Composing_ASP.NET
{
    public class PostsDataSource
    {
        private readonly PostsPresenter presenter;

        public PostsDataSource()
        {
            var kernel = (IKernel)HttpContext.Current.Application["container"];
            presenter = kernel.Get<PostsPresenter>();
        }

        public IEnumerable<IndividualPostPresenter> SelectAll()
        {
            return presenter.SelectAll();
        }

        public void Update(IndividualPostPresenter post)
        {
            presenter.Update(post);
        }
    }
}