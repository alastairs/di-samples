using System;
using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IPostService
    {
        void PublishPost(Post post);
        void PublishPostInFuture(Post post, DateTime publicationDate);
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetTopPosts();
    }
}
