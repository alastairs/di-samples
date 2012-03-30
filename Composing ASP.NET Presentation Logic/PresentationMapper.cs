using System;
using System.Collections.Generic;
using System.Linq;
using Blog.BusinessLogic.Models;

namespace Composing_ASP.NET_Presentation_Logic
{
    class PresentationMapper : IPresentationMapper
    {
        public virtual IndividualPostPresenter Map(Post post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            var presenter = new IndividualPostPresenter();

            return presenter;
        }

        public virtual IEnumerable<IndividualPostPresenter> Map(IEnumerable<Post> posts)
        {
            return posts.Select(Map);
        }

        public virtual Post Map(IndividualPostPresenter presenter)
        {
            if (presenter == null)
            {
                throw new ArgumentNullException("presenter");
            }

            return new Post
            {

            };
        }
    }
}