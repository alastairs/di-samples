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