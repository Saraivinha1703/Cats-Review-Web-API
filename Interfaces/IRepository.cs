using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Models;

namespace CatsReviewWebAPI.Interfaces {
    public interface IRepository<T> where T : class {
        ICollection<T> GetValues();
    }
}