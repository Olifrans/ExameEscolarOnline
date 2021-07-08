using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class AtendeExameViewModel
    {
        public int EstudanteId { get; set; }
        public string ExameNome { get; set; }
        public List<QnAsViewModel> QnAs { get; set; }
        public string Menssagem { get; set; }
    }
}
