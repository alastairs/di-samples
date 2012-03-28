using System;
using Blog.BusinessLogic;

namespace Composing_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IContractMapper contractMapper;

        public PostService(IPostRepository postRepository, IContractMapper contractMapper)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            if (contractMapper == null)
            {
                throw new ArgumentNullException("contractMapper");
            }

            this.postRepository = postRepository;
            this.contractMapper = contractMapper;
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
