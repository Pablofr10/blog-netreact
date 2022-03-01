using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Context
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostCategoria> PostCategoria { get; set; }
    }
}
