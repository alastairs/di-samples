using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Blog.BusinessLogic;
using Blog.DataAccess;
using Ninject;

namespace Composing_WCF
{
    public class PostServiceHostFactory : ServiceHostFactory
    {
        private readonly IKernel kernel;

        public PostServiceHostFactory()
        {
            // "Poor Man's DI". Ideally, this would be injected into this constructor by
            // whatever creates this Factory.  See also Ninject.WCF.
            kernel = new StandardKernel();
            kernel.Bind<IPostRepository>().To<PostRepository>();
            kernel.Bind<IContractMapper>().To<ContractMapper>();
            kernel.Bind<IPostService>().To<PostService>();

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
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            if (serviceType == typeof(PostService))
            {
                return new PostServiceHost(kernel, serviceType, baseAddresses);
            }
            
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
    }
}