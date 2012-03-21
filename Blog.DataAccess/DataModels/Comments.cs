using Simple.Data;

namespace Blog.DataAccess.DataModels
{
    class Comments
    {
        private readonly dynamic db = Database.OpenFile(@"Database\BlogDatabase.sdf");
    }
}
