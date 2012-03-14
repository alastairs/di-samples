using System;
using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic.Implementation
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;

        public PostService(IPostRepository postRepository)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            this.postRepository = postRepository;
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
