using backend.Models;

namespace backend.Repositories
{
    public interface IPostagemRepository
    {
        Task<IEnumerable<Post>> GetPostagens();
        Task<Post> GetPostagemById(int id);
    }
}
