using System;
using System.Collections.Generic;
using System.Text;


namespace ExameEscolar.DataAccess
{
    public class QnAs
    {
        public int Id { get; set; }

        public int ExameId { get; set; }

        public Exame Exame { get; set; }

        public string Pergunta { get; set; }

        public int Responder { get; set; }

        public string Opcao1 { get; set; }

        public string Opcao2 { get; set; }

        public string Opcao3 { get; set; }

        public string Opcao4 { get; set; }

        public ICollection<ExameResultado> ExameResultado { get; set; } = new HashSet<ExameResultado>();
    }
}
