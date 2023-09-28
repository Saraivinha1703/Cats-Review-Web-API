using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces
{
    public interface IReviewRepository : IRepository<Review>
    {
        Reviewer? GetReviewerByReview(int reviewId);
        Cat? GetCatByReview(int reviewId);
    }
}