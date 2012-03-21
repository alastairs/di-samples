using Blog.BusinessLogic.Models;

namespace Blog.BusinessLogic.Implementation
{
    class SimpleAverageRatingAlgorithm : IRatingAlgorithm
    {
        public Rating CalculateRating(Rating currentRating, int rating)
        {
            var newRating = new Rating
                                {
                                    NumberOfRatings = currentRating.NumberOfRatings + 1
                                };

            newRating.Score = (currentRating.Score + rating) / newRating.NumberOfRatings;

            return newRating;
        }
    }
}