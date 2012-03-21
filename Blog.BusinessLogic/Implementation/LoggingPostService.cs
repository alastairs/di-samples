using System;
using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic.Implementation
{
    /* Decorator adding logging functionality */
    public class LoggingPostService : IPostService
    {
        private readonly IPostService postService;
        private readonly ILoggingService loggingService;

        public LoggingPostService(IPostService postService, ILoggingService loggingService)
        {
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }

            if (loggingService == null)
            {
                throw new ArgumentNullException("loggingService");
            }

            this.postService = postService;
            this.loggingService = loggingService;
        }

        public void PublishPost(Post post)
        {
            loggingService.Log("Publishing post '{0}'", post.Title);
            postService.PublishPost(post);
        }

        public void PublishPostInFuture(Post post, DateTime publicationDate)
        {
            loggingService.Log("Setting Publication Date of post '{0}' to {1}", post.Title, publicationDate);
            postService.PublishPostInFuture(post, publicationDate);
        }

        public IEnumerable<Post> GetPosts()
        {
            loggingService.Log("Retrieving all posts");
            return postService.GetPosts();
        }

        public IEnumerable<Post> GetTopPosts()
        {
            loggingService.Log("Retrieving all posts ordered by rating");
            return postService.GetTopPosts();
        }

        public Post GetPostById(int postId)
        {
            loggingService.Log("Retrieving post with ID {0}", postId);
            return postService.GetPostById(postId);
        }

        public ITagService TagService
        {
            get { return postService.TagService; }
            set 
            { 
                loggingService.Log("Setting TagService to instance of {0}", value.GetType());
                postService.TagService = value;
            }
        }

        public void RatePost(Post post, int rating, IRatingAlgorithm ratingAlgorithm)
        {
            loggingService.Log("Calculating new rating for '{0}' with rating score {1} using strategy {2}", post.Title, rating, ratingAlgorithm.GetType());
            postService.RatePost(post, rating, ratingAlgorithm);
        }
    }
}
