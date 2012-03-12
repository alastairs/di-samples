using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IPostService
    {
        void Save(Post post);
        IEnumerable<Post> GetPosts();
        IEnumerable<Post> GetTopPosts();
    }
}
