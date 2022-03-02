using backend.Context;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PostagemRepository : IPostagemRepository
    {
        private readonly BlogDbContext _context;
        public PostagemRepository(BlogDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Post>> GetPostagens()
        {
            return await _context.Posts.ToListAsync();
        }
        public async Task<Post> GetPostagemById(int id)
        {
            return await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
