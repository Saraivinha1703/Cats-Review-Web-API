using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Respository
{
    public class CatRepository : IRepository<Cat>
    {
        private readonly DataContext _context;

        public CatRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Cat> GetValues()
        {
            return _context.Cats.OrderBy(p => p.Id).ToList();
        }

        public Cat GetValue(int id)
        {
            return _context.Cats.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool ValueExists(int id)
        {
            return _context.Cats.Any(c => c.Id == id);
        }
    }
}