using System;
using System.Collections.Generic;
using Blog.BusinessLogic;

namespace Composing_ASP.NET_Presentation_Logic
{
    public class PostsPresenter
    {
        private readonly IPostRepository postRepository;
        private readonly IPresentationMapper presentationMapper;

        public PostsPresenter(IPostRepository postRepository, IPresentationMapper presentationMapper)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            if (presentationMapper == null)
            {
                throw new ArgumentNullException("presentationMapper");
            }

            this.postRepository = postRepository;
            this.presentationMapper = presentationMapper;
        }

        public IEnumerable<IndividualPostPresenter> SelectAll()
        {
            return presentationMapper.Map(postRepository.GetAllPosts());
        }

        public void Update(IndividualPostPresenter post)
        {
            if (post == null)
            {
                throw new ArgumentNullException("post");
            }

            postRepository.Save(presentationMapper.Map(post));
        }
    }
}
