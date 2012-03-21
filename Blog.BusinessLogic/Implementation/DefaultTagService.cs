using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic.Implementation
{
    public class DefaultTagService : ITagService
    {
        public ICollection<Tag> GetTagsForPost(Post post)
        {
            return new List<Tag>();
        }
    }
}