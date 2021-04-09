using System;
using System.Collections.Generic;
using System.Text;

namespace ExameEscolar.DataAccess
{
    public class ExameResultado
    {
        public int Id { get; set; }

        public int EstudanteId { get; set; }

        public Estudante Estudante { get; set; }

        public int? ExameId { get; set; }

        public Exame Exame { get; set; }

        public int QnAsId { get; set; }

        public QnAs QnAs { get; set; }

        public int Responder { get; set; }
    }
}
