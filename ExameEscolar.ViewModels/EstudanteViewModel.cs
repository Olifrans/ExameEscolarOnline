using ExameEscolar.DataAccess;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class EstudanteViewModel
    {
        public EstudanteViewModel()
        {
                
        }

        public int Id { get; set; }
        [Required]
        [Display(Name = "Nome do Estudante")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Usuario Nome")]
        public string UsuarioNome { get; set; }
        [Required]
        public string Senha { get; set; }
        [Required]
        [Display(Name = "Contato")]
        public string Contato { get; set; }

        [Display(Name = "CVNomeArquivo")]
        public string CVNomeArquivo { get; set; }

        public string ImagemNomeArquivo { get; set; }

        public int? GroupsId { get; set; }

        public IFormFile ImagemArquivo { get; set; }

        public IFormFile CVArquivo { get; set; }

        public int ContaTotal { get; set; }

        public List<EstudanteViewModel> EstudanteList { get; set; }


        public EstudanteViewModel(Estudante model)
        {
            Id = model.Id;
            Nome = model.Nome ?? "";
            UsuarioNome = model.UsuarioNome;
            Senha = model.Senha;
            Contato = model.Contato ?? "";
            CVNomeArquivo = model.CVNomeArquivo ?? "";
            ImagemNomeArquivo = model.ImagemNomeArquivo ?? "";
            GroupsId = model.GroupsId;

        }

        public Estudante ConvertEstudanteViewModel(EstudanteViewModel vm)
        {
            return new Estudante
            {
                Id = vm.Id,
                Nome = vm.Nome ?? "",
                UsuarioNome = vm.UsuarioNome,
                Senha = vm.Senha,
                Contato = vm.Contato ?? "",
                CVNomeArquivo = vm.CVNomeArquivo ?? "",
                ImagemNomeArquivo = vm.ImagemNomeArquivo ?? "",
                GroupsId = vm.GroupsId,
            };
        }
    }
}
