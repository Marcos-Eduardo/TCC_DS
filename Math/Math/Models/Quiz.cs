using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    [Table("Quiz")]
    public class Quiz
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Por favor, informe o título do Quiz.")]
        [StringLength(50, ErrorMessage = "O título deve possuir no máximo 50 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Conteúdo")]
        [Required(ErrorMessage = "Por favor, informe o Conteúdo.")]
        public int ConteudoId { get; set; }

        public Conteudo Conteudo { get; set; }

        public IEnumerable<Questao> Questoes { get; set; }
    }
}
