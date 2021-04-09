using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class ResultadoViewModel
    {
        public int EstudanteId { get; set; }
                
        public string ExameNome { get; set; }

        public int TotalDeQuestoes { get; set; }

        public int RespostaCorreta { get; set; }

        public int RespostaErrada { get; set; }

    }
}
