using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class EstudanteCheckBoxListViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Selecione { get; set; }
    }
}
