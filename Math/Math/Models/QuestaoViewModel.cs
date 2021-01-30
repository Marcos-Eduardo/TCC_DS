using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Math.Models
{
    public class QuestaoViewModel
    {
        public int numb { get; set; }
        public string question { get; set; }
        public string answer { get; set; }
        public List<string> options { get; set; }
        public QuestaoViewModel()
        {
            options = new List<string>();
        }
    }
}
