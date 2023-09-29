namespace CatsReviewWebAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        ICollection<T> GetValues();
        T? GetValue(int id);
        bool ValueExists(int id);
        bool CreateObject(T obj);
        bool UpdateObject(T obj);
        bool Save();
    }
}