using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace PrjBiblioteca.Models
{
    public class Livro
    {
        [Key]
        public int LivroId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")] // Data annotation campo obrigatório
        [Display(Name = "Título")] // Texto apresentado na View
        [StringLength(200, ErrorMessage = "O campo {0} deve ter no máximo {1} caracteres")] // Tamanho do campo
        public string Titulo { get; set; }

        [Range(1, 300, ErrorMessage = "O campo {0} deve estar entre {1} e {2}")]
        public int Quantidade { get; set; }

        public ICollection<LivroAutor> LivroAutores { get; set; }
        public ICollection<LivroEmprestimo> LivroEmprestimos { get; set; }

    }
}