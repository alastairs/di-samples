using Simple.Data;

namespace Blog.DataAccess
{
    class Comments
    {
        private readonly dynamic db = Database.OpenFile(@"Database\BlogDatabase.sdf");
    }
}
