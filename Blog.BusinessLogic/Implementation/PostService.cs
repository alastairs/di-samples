using System;
using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic.Implementation
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private ITagService tagService;

        public PostService(IPostRepository postRepository)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            this.postRepository = postRepository;
        }

        /* This is an example of Property Injection. Note how careful we are that it has a valid value at all times. */
        public ITagService TagService
        {
            get
            {
                // Lazily initialise the property to a local default

                if (tagService == null)
                {
                    tagService = new DefaultTagService();
                }

                return tagService;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                if (tagService != null)
                {
                    throw new InvalidOperationException("The TagService can only be defined once.");
                }

                tagService = value;
            }
        }

        public void PublishPost(Post post)
        {
            postRepository.Save(post);
        }

        public void PublishPostInFuture(Post post, DateTime publicationDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetPosts()
        {
            return postRepository.GetAllPosts();
        }

        public IEnumerable<Post> GetTopPosts()
        {
            throw new NotImplementedException();
        }

        public Post GetPostById(int postId)
        {
            return postRepository.GetById(postId);
        }
    }
}
