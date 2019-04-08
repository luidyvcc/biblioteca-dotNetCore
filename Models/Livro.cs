using System.ComponentModel.DataAnnotations;

namespace PrjBiblioteca.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Titulo { get; set; }

    }
}