using System;
using System.Collections.Generic;
using Blog.BusinessLogic.Implementation;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IPostService
    {
        void PublishPost(Post post);
        void PublishPostInFuture(Post post, DateTime publicationDate);
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetTopPosts();
        Post GetPostById(int postId);

        /// <summary>
        /// This is an example of Method Injection.
        /// </summary>
        /// <param name="post">This is not a dependency</param>
        /// <param name="commentService">This is a dependency</param>
        void AddComment(Post post, ICommentService commentService);
    }
}
