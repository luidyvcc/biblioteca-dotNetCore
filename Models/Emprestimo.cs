using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace PrjBiblioteca.Models
{
    public class Emprestimo
    {
        [Key]
        public int EmprestimoID { get; set; }

        public int UsuarioID { get; set; }      
        public virtual Usuario Usuario { get; set; } 

        [Display(Name = "Data de inicio")]
        [DataType(DataType.Date, ErrorMessage="Data com formato inválido!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime DataInicio { get; set; }

        [Display(Name = "Data de fim")]
        [DataType(DataType.Date, ErrorMessage="Data com formato inválido!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime DataFim { get; set; }

        [Display(Name = "Data de devolução")]
        [DataType(DataType.Date, ErrorMessage="Data com formato inválido!")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)] 
        public DateTime DataDevolucao { get; set; }

        public ICollection<LivroEmprestimo> EmprestimoLivros { get; set; }
    }
}