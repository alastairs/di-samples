using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IPostService
    {
        void PublishPost(Post post);
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetTopPosts();
    }
}
