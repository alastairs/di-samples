using System.Collections.Generic;
using Blog.BusinessLogic.Models;

namespace Composing_ASP.NET_Presentation_Logic
{
    interface IPresentationMapper
    {
        IndividualPostPresenter Map(Post post);
        IEnumerable<IndividualPostPresenter> Map(IEnumerable<Post> posts);
        Post Map(IndividualPostPresenter presenter);
    }
}
