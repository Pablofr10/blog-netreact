using backend.Context;
using backend.Models.Dtos.Response;
using backend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class PostagemRepository : BaseRepository, IPostagemRepository
    {
        private readonly BlogDbContext _context;
        public PostagemRepository(BlogDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PostagemResponse>> GetPostagens()
        {
            return await _context.Posts
                .Include(x => x.Categorias)
                .ThenInclude(c => c.Categoria)
                .Select(post => PostagemResponse.ToViewModel(post))
                .ToListAsync();
        }
        public async Task<PostagemResponse> GetPostagemById(int id)
        {
            return await _context.Posts
                .Select(post => PostagemResponse.ToViewModel(post))
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
