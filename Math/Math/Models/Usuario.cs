using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    public class Usuario: IdentityUser
    {
        [Required(ErrorMessage = "Por favor, informe o Nome.")]
        [StringLength(50, ErrorMessage = "O nome não deve possuir mais de 50 caracteres.")]
        public string Nome { get; set; }

        [StringLength(15, ErrorMessage = "O apelido não deve possuir mais de 15 caracteres.")]
        public string Apelido { get; set; }

        [Required(ErrorMessage = "Por favor, informe a Data de Nascimento.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public string Roles { get; set; }
    }
}
