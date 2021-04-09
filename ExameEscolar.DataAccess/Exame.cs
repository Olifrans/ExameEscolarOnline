using System;
using System.Collections.Generic;
using System.Text;

namespace ExameEscolar.DataAccess
{
    public class Exame
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public DateTime DataInicio { get; set; }

        public int Hora { get; set; }

        public int GroupsId { get; set; }

        public Groups Groups { get; set; }

        public ICollection<ExameResultado> ExameResultado { get; set; } = new HashSet<ExameResultado>();

        public ICollection<QnAs> QnAs { get; set; } = new HashSet<QnAs>();
    }
}
