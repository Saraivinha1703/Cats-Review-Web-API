using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly DataContext _context;
        public ReviewRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Review> GetValues()
        {
            return _context.Reviews.OrderBy(r => r.Id).ToList();
        }

        public Review? GetValue(int id)
        {
            return _context.Reviews.Where(r => r.Id == id).FirstOrDefault();
        }

        public Cat? GetCatByReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).Select(r => r.Cat).FirstOrDefault();
        }

        public Reviewer? GetReviewerByReview(int reviewId)
        {
            return _context.Reviews.Where(r => r.Id == reviewId).Select(r => r.Reviewer).FirstOrDefault();
        }

        public bool ValueExists(int id)
        {
            return _context.Reviews.Any(c => c.Id == id);
        }

        public bool CreateObject(Review obj)
        {
            _context.Add(obj);
            return Save();
        }

        public bool UpdateObject(Review obj)
        {
            _context.Update(obj);
            return Save();
        }

        public bool Save()
        {
            int num = _context.SaveChanges();
            return num > 0 ? true : false;
        }
    }
}