using ExameEscolar.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class GroupsViewModel
    {
        public GroupsViewModel()
        {
                
        }

        public int Id { get; set; }
        [Required]
        [Display(Name ="Nome do Grupo")]
        public string Nome { get; set; }
        [Required]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public int UsuarioId { get; set; }


        public List<GroupsViewModel> GroupList { get; set; }

        public int ContaTotal { get; set; }

        public List<EstudanteCheckBoxListViewModel> estudanteChecks  { get; set; }


        public GroupsViewModel(Groups model)
        {
            Id = model.Id;
            Nome = model.Nome ?? "";
            Descricao = model.Descricao;
            UsuarioId = model.UsuarioId;            
        }

        public Groups ConvertGroupsViewModel(GroupsViewModel vm)
        {
            return new Groups
            {
                Id = vm.Id,
                Nome = vm.Nome ?? "",
                Descricao = vm.Descricao,
                UsuarioId = vm.UsuarioId,
            };
        }

    }
}
