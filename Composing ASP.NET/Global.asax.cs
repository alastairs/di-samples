using System;
using System.Web;
using Blog.BusinessLogic;
using Blog.BusinessLogic.Implementation;
using Blog.DataAccess;
using Composing_ASP.NET.PresentationLogic;
using Ninject;

namespace Composing_ASP.NET
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var kernel = new StandardKernel();

            kernel.Bind<PostPresenter>().ToSelf();
            
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IRatingAlgorithm>().To<SimpleAverageRatingAlgorithm>();

            Application["container"] = kernel;
        }
    }
}
