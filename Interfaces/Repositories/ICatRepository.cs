using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces
{
    public interface ICatRepository : IRepository<Cat>
    {
        Owner? GetOwnerByCat(int catId);
        ICollection<Review> GetCatReviews(int catId);
        ICollection<Reviewer?> GetCatReviewers(int catId);
    }
}