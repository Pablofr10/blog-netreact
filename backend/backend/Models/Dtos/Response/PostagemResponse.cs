using backend.Models.Entities;

namespace backend.Models.Dtos.Response
{
    public class PostagemResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Ativa { get; set; }
        public List<CategoriaResponse> Categorias { get; set; }

        public static PostagemResponse ToViewModel(Post model)
        {

            var categorias = model.Categorias != null ?
                    model.Categorias.Select(x => 
                    new CategoriaResponse { Nome = x.Categoria.Nome,Id = x.Categoria.Id }).ToList()
                    : new List<CategoriaResponse>();

            return new PostagemResponse
            {
                Id = model.Id,
                Conteudo = model.Conteudo,
                Titulo = model.Titulo,
                Ativa = model.Ativa,
                Categorias = categorias
            };
        }
    }
}
