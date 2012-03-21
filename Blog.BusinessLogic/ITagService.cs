using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface ITagService
    {
        ICollection<Tag> GetTagsForPost(Post post);
    }
}