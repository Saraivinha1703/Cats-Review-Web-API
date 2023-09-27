using CatsReviewWebAPI.Data;
using CatsReviewWebAPI.Models;
using Microsoft.EntityFrameworkCore.Storage;

namespace CatsReviewWebAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetValues();
        T GetValue(int id);
        bool ValueExists(int id);
    }
}