using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces
{
    public interface ICountryRepository : IRepository<Country>
    {
        Country? GetCountryByOwner(int ownerId);
        ICollection<Owner> GetOwnersByContry(int countryId);
    }
}