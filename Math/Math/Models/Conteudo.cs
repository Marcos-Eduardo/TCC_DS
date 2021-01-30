using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    [Table("Conteudo")]
    public class Conteudo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Por favor, informe o título do conteúdo.")]
        [StringLength(50, ErrorMessage = "O título deve possuir no máximo 50 caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Por favor, informe a descrição do conteúdo.")]
        [StringLength(1000, ErrorMessage = "A descrição deve possuir no máximo 1000 caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Nível")]
        [Required(ErrorMessage = "Por favor, informe o Nível.")]
        public int NivelId { get; set; }

        public Nivel Nivel { get; set; }

        [NotMapped]
        public int NumeroOrdem { get; set; }
    }
}
