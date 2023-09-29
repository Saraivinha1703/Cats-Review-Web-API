using System.Globalization;
using System.IO.Compression;
using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Interfaces;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly DataContext _context;

        public OwnerRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Owner> GetValues()
        {
            return _context.Owners.OrderBy(o => o.Id).ToList();
        }

        public Owner? GetValue(int id)
        {
            return _context.Owners.Where(o => o.Id == id).FirstOrDefault();
        }

        public Cat? GetCatByOwner(int ownerId)
        {
            return _context.CatOwners.Where(co => co.OwnerId == ownerId).Select(co => co.Cat).FirstOrDefault();
        }

        public Country? GetCountryByOwner(int ownerId)
        {
            return _context.Owners.Where(o => o.Id == ownerId).Select(o => o.Country).FirstOrDefault();
        }

        public bool ValueExists(int id)
        {
            return _context.Owners.Any(o => o.Id == id);
        }

        public bool CreateObject(Owner obj)
        {
            _context.Add(obj);
            return Save();
        }

        public bool UpdateObject(Owner obj)
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