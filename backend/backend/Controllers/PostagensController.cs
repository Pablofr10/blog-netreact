using backend.Models.Dtos.Request;
using backend.Models.Entities;
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
        public async Task<IActionResult> PostPostagem(PostagemRequest request)
        {
            var postagem = Post.PostToModel(request);

            postagem.Categorias = CriaCategorias(request.Categorias);

            _repository.Add(postagem);

            return await _repository.SaveChangesAsync()
                ? Ok("Postagem criada!")
                : BadRequest("Erro ao criar postagem");
        }

        private List<PostCategoria> CriaCategorias(List<int> idsCategorias)
        {
            var categorias = new List<PostCategoria>();

            foreach (int categoriaId in idsCategorias)
            {
                categorias.Add(new PostCategoria { CategoriaId = categoriaId });
            }
            return categorias;
        }
    }
}
