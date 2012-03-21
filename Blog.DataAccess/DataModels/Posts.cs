using Blog.BusinessLogic.Models;
using Simple.Data;

namespace Blog.DataAccess.DataModels
{
    class Posts
    {
        private readonly dynamic db = Database.OpenFile(@"Database\BlogDatabase.sdf");

        public Post GetById(int id)
        {
            var databasePost = db.Posts.FindById(id);
            return new Post();
        }
    }
}
