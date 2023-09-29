using CatsReviewWebAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CatsReviewWebAPI.Interfaces
{
    public interface ICatRepository : IRepository<Cat>
    {
        Category? GetCategoryByCat(int catId);
        Owner? GetOwnerByCat(int catId);
        ICollection<Review> GetCatReviews(int catId);
        ICollection<Reviewer?> GetCatReviewers(int catId);
        bool CreateObject(Cat cat, CatOwner catOwner, CatCategory catCategory);
    }
}