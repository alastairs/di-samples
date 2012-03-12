using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IPostService
    {
        void SavePost(Post post);
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetTopPosts();
    }
}
