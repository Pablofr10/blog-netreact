using System.ComponentModel.DataAnnotations;

namespace backend.Models.Dtos.Request
{
    public class CategoriaRequest
    {
        [Required(ErrorMessage = "È obrigatório nome da categoria")]
        public string Nome { get; set; }
    }
}
