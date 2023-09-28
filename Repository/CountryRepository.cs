using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Repository {
    public class CountryRepository : ICountryRepository
    {
        private readonly DataContext _context;

        public CountryRepository(DataContext context)
        {
            _context = context;
        }
        public ICollection<Country> GetValues()
        {
            return _context.Countries.OrderBy(c => c.Id).ToList();
        }
        public Country? GetValue(int id)
        {
            return _context.Countries.Where(c => c.Id == id).FirstOrDefault();
        }

        public bool ValueExists(int id)
        {
            return _context.Countries.Any(c => c.Id == id);
        }

        public Country? GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public ICollection<Owner> GetOwnersByContry(int countryId)
        {
            return _context.Owners.Where(o => o.Country.Id == countryId).ToList();
        }
    }
}