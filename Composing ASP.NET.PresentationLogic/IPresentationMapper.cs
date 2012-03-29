using System;
using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Composing_ASP.NET.PresentationLogic
{
    public interface IPresentationMapper
    {
        PostPresenter Map(Post post);
        IEnumerable<PostPresenter> Map(IEnumerable<Post> posts);
        Post Map(PostPresenter postPresenter);
    }

    class PresentationMapper : IPresentationMapper
    {
        public PostPresenter Map(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            var presenter = new PostPresenter()
        }

        public IEnumerable<PostPresenter> Map(IEnumerable<Post> posts)
        {
            throw new System.NotImplementedException();
        }

        public Post Map(PostPresenter postPresenter)
        {
            throw new System.NotImplementedException();
        }
    }
}