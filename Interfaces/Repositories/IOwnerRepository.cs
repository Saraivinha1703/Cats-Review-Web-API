using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces {
    public interface IOwnerRepository : IRepository<Owner> {
        Country? GetCountryByOwner(int ownerId);
        ICollection<Cat?> GetCatsByOwner(int ownerId);
    }
}