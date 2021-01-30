using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    public class ConteudoViewModel
    {
        public Conteudo Conteudo { get; set; }

        public IEnumerable<Dica> Dicas { get; set; }
    }
}
