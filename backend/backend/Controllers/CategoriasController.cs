using backend.Models.Dtos.Request;
using backend.Models.Entities;
using backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categorias = await _repository.GetCategorias();

            return categorias.Any() 
                ? Ok(categorias)
                : NotFound("Categorias não encontradas");
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var categoria = await _repository.GetCategoriasById(id);

            return categoria != null
                ? Ok(categoria)
                : NotFound("Categorias não encontradas");
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoria(CategoriaRequest request)
        {
            _repository.Add(new Categoria() { Nome = request.Nome });

            return await _repository.SaveChangesAsync()
                ? Ok("Categoria adicionada com sucesso")
                : BadRequest("Erro ao adicionar categoria");
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> PutCategoria(int id, CategoriaRequest request)
        {
            var categoria = await _repository.GetCategoriasById(id);

            if (categoria == null) return NotFound("Categoria não existe");

            _repository.Update(new Categoria() { Nome = request.Nome});

            return await _repository.SaveChangesAsync()
                ? Ok("Categoria atualizada com sucesso")
                : BadRequest("Erro ao atualizar categoria");
        }
    }
}
