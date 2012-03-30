using System;
using Blog.BusinessLogic;

namespace Composing_ASP.NET.PresentationLogic
{
    public class PostPresenter
    {
        private readonly IPostService postService;
        private readonly IPresentationMapper presentationMapper;

        public PostPresenter(IPostService postService, IPresentationMapper presentationMapper)
        {
            if (postService == null)
            {
                throw new ArgumentNullException("postService");
            }

            if (presentationMapper == null)
            {
                throw new ArgumentNullException("presentationMapper");
            }

            this.postService = postService;
            this.presentationMapper = presentationMapper;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Body { get; set; }

        public DateTime PublicationDate { get; set; }
    }
}
