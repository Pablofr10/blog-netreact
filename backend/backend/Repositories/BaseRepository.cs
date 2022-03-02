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
        public void AddRange<T>(T entity)
        {
            _context.AddRange(entity);
        }

        public void Delete<T>(T entity)
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity)
        {
            _context.Update(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        
    }
}
