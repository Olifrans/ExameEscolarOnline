using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class PaginaDeResultado<T> where T: class
    {
        public List<T> Data { get; set; }
        public int TotalItems { get; set; }
        public int PaginaNumero { get; set; }
        public int PaginaTamanho { get; set; }
    }
}
