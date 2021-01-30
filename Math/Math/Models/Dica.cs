using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    [Table("Dica")]
    public class Dica
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Por favor, informe o título do conteúdo.")]
        [StringLength(50, ErrorMessage = "O título deve possuir no máximo 50 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor, informe a descrição do conteúdo.")]
        [StringLength(2500, ErrorMessage = "A descrição deve possuir no máximo 2500 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Link do Vídeo")]
        [Required(ErrorMessage = "Por favor, informe o Link do Vídeo.")]
        public string LinkVideo { get; set; }

        [Display(Name = "Conteúdo")]
        [Required(ErrorMessage = "Por favor, informe o Conteúdo.")]
        public int ConteudoId { get; set; }

        public Conteudo Conteudo { get; set; }
    }
}
