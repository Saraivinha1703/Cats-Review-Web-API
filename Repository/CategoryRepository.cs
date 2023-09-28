using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Repository {
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _context;

        public CategoryRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Category> GetValues()
        {
            return _context.Categories.OrderBy(c => c.Id).ToList();
        }

        public List<Cat?> GetCatsByCategory(int categoryId) {
            return _context.CatCategories.Where(cc => cc.CategoryId == categoryId).Select(cc => cc.Cat).ToList();
        }

        public Category? GetValue(int id)
        {
            return _context.Categories.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool ValueExists(int id)
        {
            return _context.Categories.Any(c => c.Id == id);
        }
    }
}