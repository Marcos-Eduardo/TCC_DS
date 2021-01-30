using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    [Table("Questao")]
    public class Questao
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public int Numero { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Por favor, informe o título da Questão.")]
        [StringLength(50, ErrorMessage = "O título deve possuir no máximo 50 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Alternativa 1")]
        [Required(ErrorMessage = "Por favor, informe a Alternativa 1.")]
        [StringLength(60, ErrorMessage = "A Alternativa 1 deve possuir no máximo 60 caracteres.")]
        public string Alternativa1 { get; set; }

        [Display(Name = "Alternativa 2")]
        [Required(ErrorMessage = "Por favor, informe a Alternativa 2.")]
        [StringLength(60, ErrorMessage = "A Alternativa 2 deve possuir no máximo 60 caracteres.")]
        public string Alternativa2 { get; set; }

        [Display(Name = "Alternativa 3")]
        [Required(ErrorMessage = "Por favor, informe a Alternativa 3.")]
        [StringLength(60, ErrorMessage = "A Alternativa 3 deve possuir no máximo 60 caracteres.")]
        public string Alternativa3 { get; set; }

        [Display(Name = "Alternativa 4")]
        [Required(ErrorMessage = "Por favor, informe a Alternativa 4.")]
        [StringLength(60, ErrorMessage = "A Alternativa 4 deve possuir no máximo 60 caracteres.")]
        public string Alternativa4 { get; set; }

        [Display(Name = "Resposta")]
        [Required(ErrorMessage = "Por favor, informe a Resposta.")]
        [StringLength(60, ErrorMessage = "A Resposta deve possuir no máximo 60 caracteres.")]
        public string Resposta { get; set; }

        [Display(Name = "Quiz")]
        [Required(ErrorMessage = "Por favor, informe o Quiz.")]
        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }
    }
}
