using Simple.Data;

namespace Blog.DataAccess.DataModels
{
    class Posts
    {
        private readonly dynamic db = Database.OpenFile(@"Database\BlogDatabase.sdf");
    }
}
