using backend.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Dtos.Request
{
    public class PostagemRequest
    {
        [Required(ErrorMessage = "Título obrigatório")]
        [MinLength(5, ErrorMessage = "Obrigatório informar pelo menos 5 caracteres")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Conteúdo obrigatório")]
        [MinLength(15, ErrorMessage = "Obrigatório informar pelo menos 15 caracteres")]
        public string Conteudo { get; set; }
        public bool Ativa { get; set; }
        public List<int> Categorias { get; set; }
    }
}
