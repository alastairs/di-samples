using System;
using System.Web.UI;
using Composing_ASP.NET.PresentationLogic;
using Ninject;

namespace Composing_ASP.NET
{
    public partial class Post : Page
    {
        private PostPresenter presenter;

        protected void Page_Load(object sender, EventArgs e)
        {
            var kernel = Application["container"] as IKernel;
            
            presenter = kernel.Get<PostPresenter>();
        }
    }
}