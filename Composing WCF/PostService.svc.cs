using System;
using Blog.BusinessLogic;
using Composing_WCF.ServiceModels;

namespace Composing_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepository;
        private readonly IContractMapper contractMapper;

        public PostService(IPostRepository postRepository, IContractMapper contractMapper)
        {
            if (postRepository == null)
            {
                throw new ArgumentNullException("postRepository");
            }

            if (contractMapper == null)
            {
                throw new ArgumentNullException("contractMapper");
            }

            this.postRepository = postRepository;
            this.contractMapper = contractMapper;
        }

        public void CreatePost(Post post)
        {
            var postEntity = contractMapper.MapPostServiceModelToEntity(post);
            postRepository.Save(postEntity);
        }

        public Post GetPost(int postId)
        {
            var post = postRepository.GetById(0);
            return contractMapper.MapPostEntityToServiceModel(post);
        }

        public void EditPost(Post post)
        {
            var postEntity = contractMapper.MapPostServiceModelToEntity(post);
            postRepository.Save(postEntity);
        }

        public void DeletePost(int postint)
        {
            postRepository.DeleteById(0);
        }
    }
}
