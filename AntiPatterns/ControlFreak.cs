using Blog.BusinessLogic;
using Blog.DataAccess;

namespace AntiPatterns
{
    public class ControlFreak
    {
        private readonly IPostRepository postRepository;

        public ControlFreak()
        {
            // Directly instantiating a dependency here is an example of being a Control Freak
            postRepository = new PostRepository();
        }

        public void Foo()
        {
            postRepository.GetAllPosts();
        }
    }
}
