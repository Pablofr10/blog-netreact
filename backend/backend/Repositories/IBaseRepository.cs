namespace backend.Repositories
{
    public interface IBaseRepository
    {
        void Add<T>(T entity);
        void Update<T>(T entity);
        void Delete<T>(T entity);
        Task<bool> SaveChangesAsync();
    }
}
