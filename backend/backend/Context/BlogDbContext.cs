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


        protected override void OnModelCreating(ModelBuilder moldelBuilder)
        {
            var post = moldelBuilder.Entity<Post>();
            post.ToTable("tb_post");
            post.HasKey(x => x.Id);
            post.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            post.Property(x => x.Conteudo).HasColumnName("conteudo").IsRequired();
            post.Property(x => x.Titulo).HasColumnName("titulo").IsRequired();
            post.Property(x => x.Ativa).HasColumnName("ativa");

            var categorias = moldelBuilder.Entity<Categoria>();
            categorias.ToTable("tb_categoria");
            categorias.HasKey(c => c.Id);
            categorias.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd(); ;
            categorias.Property(x => x.Nome).HasColumnName("nome").IsRequired();

            var postCategoria = moldelBuilder.Entity<PostCategoria>();
            postCategoria.ToTable("tb_post_categoria");
            postCategoria.HasKey(src => new { src.PostId, src.CategoriaId });

            postCategoria.HasOne<Post>(src => src.Post)
                .WithMany(x => x.Categorias)
                .HasForeignKey(x => x.PostId);

            postCategoria.HasOne<Categoria>(src => src.Categoria)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.CategoriaId);
        }
    }
}
