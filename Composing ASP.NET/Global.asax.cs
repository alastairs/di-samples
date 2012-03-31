using System;
using System.Web;
using Blog.BusinessLogic;
using Blog.BusinessLogic.Implementation;
using Blog.DataAccess;
using Composing_ASP.NET_Presentation_Logic;
using Ninject;

namespace Composing_ASP.NET
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            var kernel = new StandardKernel();

            kernel.Bind<PostsPresenter>().ToSelf();

            kernel.Bind<IPresentationMapper>().To<PresentationMapper>();
            
            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IRatingAlgorithm>().To<SimpleAverageRatingAlgorithm>();
            
            /* 
             * Wire up an Ambient Context.
             * 
             * Could be achieved by decorating DateTimeContext.Current with [Inject].
             * You'd then need to bind the type to the required implementation as follows:
             * 
             * kernel.Bind<DateTimeContext>().To<DefaultDateTimeContext>();
             *
             * Unfortunately, this then means that the BusinessLogic assembly is tied to the
             * IoC container, as DateTimeContext is defined in that layer. Given how easy it
             * is to wire this up manually, it's not worth bringing an IoC container into the
             * picture unless you really need to.
             */

            DateTimeContext.Current = new DefaultDateTimeContext();
            
            Application["container"] = kernel;
        }
    }
}
