using backend.Models.Dtos.Response;


namespace backend.Repositories
{
    public interface IPostagemRepository : IBaseRepository
    {
        Task<IEnumerable<PostagemResponse>> GetPostagens();
        Task<PostagemResponse> GetPostagemById(int id);
    }
}
