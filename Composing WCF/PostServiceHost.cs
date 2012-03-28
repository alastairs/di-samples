using System;
using System.ServiceModel;
using Ninject;

namespace Composing_WCF
{
    public class PostServiceHost : ServiceHost
    {
        public PostServiceHost(IKernel kernel, Type serviceType, Uri[] baseAddresses)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            var contracts = ImplementedContracts.Values;
            foreach (var contract in contracts)
            {
                var instanceProvider = new BlogInstanceProvider(kernel);
                contract.Behaviors.Add(instanceProvider);
            }
        }
    }
}