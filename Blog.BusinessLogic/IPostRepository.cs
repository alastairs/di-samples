using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IPostRepository
    {
        void Save(Post post);
        IEnumerable<Post> GetAllPosts();
        Post GetById(int id);
    }
}
