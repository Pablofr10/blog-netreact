using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostagensController : ControllerBase
    {
        private readonly IPostagemRepository _repository;

        public PostagensController(IPostagemRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var posts = await _repository.GetPostagens();

            return posts.Any() 
                ? Ok(posts)
                : NotFound();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var post = await _repository.GetPostagemById(id);

            return post != null
                ? Ok(post)
                : NotFound();
        }

        [HttpPost]
    }
}
