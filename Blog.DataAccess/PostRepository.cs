using System.Collections.Generic;
using Blog.BusinessLogic;
using Blog.BusinessLogic.Models;
using Simple.Data;

namespace Blog.DataAccess.DataModels
{
    class PostRepository : IPostRepository
    {
        private readonly dynamic db = Database.OpenFile(@"Database\BlogDatabase.sdf");

        public void Save(Post post)
        {
            db.Posts.Upsert(post);
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return db.All();
        }

        public Post GetById(int id)
        {
            return db.Posts.FindById(id);
        }
    }
}
