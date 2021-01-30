using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    public class NivelViewModel
    {
        public Nivel Nivel { get; set; }

        public IEnumerable<Conteudo> Conteudos { get; set; }
    }
}
