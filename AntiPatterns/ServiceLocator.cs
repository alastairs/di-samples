using System;
using Blog.BusinessLogic;
using Ninject;

namespace AntiPatterns
{
    class ServiceLocator
    {
        private readonly IKernel kernel;

        public ServiceLocator(IKernel kernel)
        {
            if (kernel == null)
            {
                throw new ArgumentNullException("kernel");
            }

            this.kernel = kernel;
        }

        public void Foo()
        {
            var postRepository = kernel.Get<IPostRepository>();
            postRepository.GetAllPosts();
        }
    }
}
