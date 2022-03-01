namespace backend.Models
{
    public class PostCategoria
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public Post Posts { get; set; }
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
    }
}
