using Composing_WCF.ServiceModels;
using PostEntity=Blog.BusinessLogic.Models.Post;

namespace Composing_WCF
{
    public class ContractMapper : IContractMapper
    {
        public PostEntity MapPostServiceModelToEntity(Post postServiceModel)
        {
            return new PostEntity
            {
                Title = postServiceModel.Title,
                Summary = postServiceModel.Summary,
                Body = postServiceModel.Body
            };
        }

        public Post MapPostEntityToServiceModel(PostEntity postEntity)
        {
            return new Post
            {
                Title = postEntity.Title,
                Summary = postEntity.Summary,
                Body = postEntity.Body
            };
        }
    }
}