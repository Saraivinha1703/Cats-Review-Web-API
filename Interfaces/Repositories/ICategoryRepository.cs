using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        public List<Cat?> GetCatsByCategory(int categoryId);
    }
}