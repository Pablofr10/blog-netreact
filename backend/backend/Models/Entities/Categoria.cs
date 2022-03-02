namespace backend.Models.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<PostCategoria> Posts { get; set; }
    }
}
