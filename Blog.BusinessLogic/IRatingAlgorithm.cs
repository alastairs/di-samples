using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic
{
    public interface IRatingAlgorithm
    {
        Rating CalculateRating(Rating currentRating, int rating);
    }
}