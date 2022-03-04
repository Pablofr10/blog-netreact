using backend.Context;
using backend.Models.Dtos.Response;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class CategoriaRepository : BaseRepository, ICategoriaRepository
    {
        private readonly BlogDbContext _context;

        public CategoriaRepository(BlogDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<CategoriaResponse>> GetCategorias()
        {
            return await _context.Categorias
                .Select(categoria => new CategoriaResponse()
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                }).ToListAsync();
        }

        public async Task<CategoriaResponse> GetCategoriasById(int id)
        {
            return await _context.Categorias
                .Where(x => x.Id == id)
                .Select(categoria => new CategoriaResponse()
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                }).FirstOrDefaultAsync();
        }
    }
}
