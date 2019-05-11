using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PrjBiblioteca.Models
{
    public class Autor
    {
        [Key]
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Display(Name = "Nome")] 
        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")]
        public string Nome { get; set; }

        public ICollection<LivroAutor> AutorLivros { get; set; }
    }
}