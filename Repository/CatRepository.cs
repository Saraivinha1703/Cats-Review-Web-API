using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Repository
{
    public class CatRepository : ICatRepository
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

        public Cat? GetValue(int id)
        {
            return _context.Cats.Where(c => c.Id == id).FirstOrDefault();
        }
        
        public Owner? GetOwnerByCat(int catId)
        {
            return _context.CatOwners.Where(co => co.CatId == catId).Select(co => co.Owner).FirstOrDefault();
        }

        public ICollection<Review> GetCatReviews(int catId)
        {
            return _context.Reviews.Where(r => r.Cat.Id == catId).ToList();
        }

        public ICollection<Reviewer?> GetCatReviewers(int catId)
        {
            return _context.Reviews.Where(r => r.Cat.Id == catId).Select(r => r.Reviewer).ToList();
        }
        public bool ValueExists(int id)
        {
            return _context.Cats.Any(c => c.Id == id);
        }


    }
}