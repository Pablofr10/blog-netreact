using backend.Models.Entities;

namespace backend.Models.Dtos.Response
{
    public class PostagemResponse
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Ativa { get; set; }
        public List<string> Categorias { get; set; }

        public static PostagemResponse ToViewModel(Post model)
        {

            var categorias = model.Categorias != null ?
                    model.Categorias.Select(x => x.Categoria.Nome).ToList()
                    : new List<string>();

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
