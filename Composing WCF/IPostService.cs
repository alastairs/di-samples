using System.ServiceModel;
using Composing_WCF.ServiceModels;

namespace Composing_WCF
{
    [ServiceContract]
    public interface IPostService
    {
        [OperationContract]
        void CreatePost(Post post);

        [OperationContract]
        Post GetPost(int postId);

        [OperationContract]
        void EditPost(Post post);

        [OperationContract]
        void DeletePost(int postint);
    }
}
