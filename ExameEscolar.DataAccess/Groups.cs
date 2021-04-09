using System;
using System.Collections.Generic;
using System.Text;

namespace ExameEscolar.DataAccess
{
    public class Groups
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public ICollection<Estudante> Estudante { get; set; } = new HashSet<Estudante>();

        public ICollection<Exame> Exame { get; set; } = new HashSet<Exame>();

    }
}
