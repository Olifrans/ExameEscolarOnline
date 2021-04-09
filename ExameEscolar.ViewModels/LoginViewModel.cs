using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class LoginViewModel
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        [Required]
        public string UsuarioNome { get; set; }

        [Required]
        public string Senha { get; set; }

        public int Funcao { get; set; }

    }
}
