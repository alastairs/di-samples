using System;
using Blog.BusinessLogic;
using Blog.DataAccess;

namespace AntiPatterns
{
    class BastardInjection
    {
        private readonly IPostRepository postRepository;

        public BastardInjection(IPostRepository postRepository)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            this.postRepository = postRepository;
        }

        // This is bastard injection as the default implementation is not a local default: 
        // it's coming from the Data Access layer.
        public BastardInjection() : this(new PostRepository()) { }

        public void Foo()
        {
            postRepository.GetAllPosts();
        }
    }
}
