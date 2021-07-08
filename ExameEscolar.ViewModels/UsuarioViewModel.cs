using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using ExameEscolar.DataAccess;
using ExameEscolar.DataAccess.UnitOfWork;
using ExameEscolar.DataAccess.Repository;

namespace ExameEscolar.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel(Usuario model)
        {
            Id = model.Id;
            Nome = model.Nome ?? "";
            UsuarioNome = model.UsuarioNome;
            Senha = model.Senha;
            Funcao = model.Funcao;
        }

        public Usuario ConvertUsuarioViewModel(UsuarioViewModel vm)
        {
            return new Usuario
            {
                Id = vm.Id,
                Nome = vm.Nome ?? "",
                UsuarioNome = vm.UsuarioNome,
                Senha = vm.Senha,
                Funcao = vm.Funcao,
            };
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Usuario Nome")]
        public string UsuarioNome { get; set; }
        [Required]
        public string Senha { get; set; }
        public int Funcao { get; set; }

















        public List<UsuarioViewModel> UsuarioList { get; set; }

        public int ContaTotal { get; set; }

        public UsuarioViewModel()
        {
                
        }          

    }
}
