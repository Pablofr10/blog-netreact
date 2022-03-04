using backend.Context;

namespace backend.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly BlogDbContext _context;

        public BaseRepository(BlogDbContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity)
        {
            _context.Add(entity);
        }

        public virtual void AddRange<T>(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }

        public void DeleteRange<T>(T entity)
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }        
    }
}
