using System.IO.Compression;
using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Repository
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly DataContext _context;

        public ReviewerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Reviewer> GetValues()
        {
            return _context.Reviewers.OrderBy(r => r.Id).ToList();
        }

        public Reviewer? GetValue(int id)
        {
            return _context.Reviewers.Where(r => r.Id == id).FirstOrDefault();
        }

        public ICollection<Review> GetReviewerReviews(int reviewerId)
        {
            return _context.Reviews.Where(r => r.Reviewer.Id == reviewerId).ToList();
        }

        public bool ValueExists(int id)
        {
            return _context.Reviewers.Any(r => r.Id == id);
        }
    }
}