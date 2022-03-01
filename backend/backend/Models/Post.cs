namespace backend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Conteudo { get; set; }
        public bool Ativa { get; set; }
        public IList<PostCategoria> Categorias { get; set; }

    }
}
