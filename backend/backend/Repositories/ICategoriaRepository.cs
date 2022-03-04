using backend.Models.Dtos.Response;

namespace backend.Repositories
{
    public interface ICategoriaRepository : IBaseRepository
    {
        Task<List<CategoriaResponse>> GetCategorias();
        Task<CategoriaResponse> GetCategoriasById(int id);
    }
}
