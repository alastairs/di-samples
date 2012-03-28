using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using Blog.BusinessLogic;
using Ninject;

namespace Composing_WCF
{
    public class BlogInstanceProvider : IInstanceProvider, IContractBehavior
    {
        private readonly IKernel kernel;

        public BlogInstanceProvider(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            this.kernel = kernel;
        }

        public object GetInstance(InstanceContext instanceContext)
        {
            return kernel.Get<IPostRepository>();
        }

        public object GetInstance(InstanceContext instanceContext, Message message)
        {
            return GetInstance(instanceContext);
        }

        public void ReleaseInstance(InstanceContext instanceContext, object instance)
        {
            kernel.Release(instance);
        }

        public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
        {
            // Don't care about this in this sample.
        }

        public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
        {
            dispatchRuntime.InstanceProvider = this;
        }

        public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            // Don't care about this in this sample.
        }

        public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            // Don't care about this in this sample.
        }
    }
}