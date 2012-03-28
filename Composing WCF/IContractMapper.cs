using Blog.BusinessLogic.Models;

namespace Composing_WCF
{
    public interface IContractMapper
    {
        Post MapPostServiceModelToEntity(ServiceModels.Post postServiceModel);
        ServiceModels.Post MapPostEntityToServiceModel(Post postEntity);
    }
}