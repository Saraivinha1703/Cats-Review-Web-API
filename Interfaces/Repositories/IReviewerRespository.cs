using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces
{
    public interface IReviewerRepository : IRepository<Reviewer>
    {
        ICollection<Review> GetReviewerReviews(int reviewerId);
    }
}