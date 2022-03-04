using backend.Models.Dtos.Request;

namespace backend.Models.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Ativa { get; set; }
        public IList<PostCategoria> Categorias { get; set; }

        public static Post PostToModel(PostagemRequest model)
        {
            var listaCategorias = new List<PostCategoria>();

            foreach (var categoria in model.Categorias)
            {
                listaCategorias.Add(new PostCategoria { CategoriaId = categoria });
            }

            return new Post
            {
                Conteudo = model.Conteudo,
                Titulo = model.Titulo,
                Ativa = model.Ativa,
                Categorias = listaCategorias
            };
        }
    }
}
