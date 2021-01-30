using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    public class Contato
    {
        [Display(Name = "Nome", Prompt = "Nome")]
        [Required(ErrorMessage = "Por favor, informe o Nome.")]
        [StringLength(50, ErrorMessage = "O nome deve possuir no máximo 50 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Telefone", Prompt = "Telefone")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail", Prompt = "E-mail")]
        [Required(ErrorMessage = "Por favor, informe o E-mail.")]
        [EmailAddress(ErrorMessage = "Por favor, informe um E-mail válido.")]
        public string Email { get; set; }

        [Display(Name = "Mensagem", Prompt = "Mensagem")]
        [Required(ErrorMessage = "Por favor, informe a Mensagem.")]
        [StringLength(1000, ErrorMessage = "A Mensagem deve possuir no máximo 1000 caracteres.")]
        public string Mensagem { get; set; }

    }
}
