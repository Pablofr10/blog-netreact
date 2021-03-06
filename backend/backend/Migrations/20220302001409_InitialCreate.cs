using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace backend.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_categoria",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_categoria", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_post",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    titulo = table.Column<string>(type: "text", nullable: false),
                    conteudo = table.Column<string>(type: "text", nullable: false),
                    ativa = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_post", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_post_categoria",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "integer", nullable: false),
                    categoria_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_post_categoria", x => new { x.post_id, x.categoria_id });
                    table.ForeignKey(
                        name: "FK_tb_post_categoria_tb_categoria_categoria_id",
                        column: x => x.categoria_id,
                        principalTable: "tb_categoria",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tb_post_categoria_tb_post_post_id",
                        column: x => x.post_id,
                        principalTable: "tb_post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_post_categoria_categoria_id",
                table: "tb_post_categoria",
                column: "categoria_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_post_categoria");

            migrationBuilder.DropTable(
                name: "tb_categoria");

            migrationBuilder.DropTable(
                name: "tb_post");
        }
    }
}
