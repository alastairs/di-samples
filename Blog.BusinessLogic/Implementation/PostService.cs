using System;
using System.Collections.Generic;
using System.Linq;
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
            post.PublicationDate = publicationDate;
            postRepository.Save(post);
        }

        public IEnumerable<Post> GetPosts()
        {
            var posts = postRepository.GetAllPosts().ToList();
            foreach (var post in posts)
            {
                post.Tags = TagService.GetTagsForPost(post);
            }

            return posts;
        }

        public IEnumerable<Post> GetTopPosts()
        {
            return postRepository.GetAllPosts().OrderByDescending(p => p.Rating);
        }

        public Post GetPostById(int postId)
        {
            return postRepository.GetById(postId);
        }

        public void RatePost(Post post, int rating, IRatingAlgorithm ratingAlgorithm)
        {
            /* The ratingAlgorithm parameter is an example of the Strategy pattern */
            post.Rating = ratingAlgorithm.CalculateRating(post.Rating, rating);
        }
    }
}
