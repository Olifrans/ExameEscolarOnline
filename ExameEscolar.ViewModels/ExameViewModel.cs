using ExameEscolar.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.ViewModels
{
    public class ExameViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Exame Nome")]
        public string Titulo { get; set; }
        [Required]
        [Display(Name = "Exame Descrição")]
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public int Hora { get; set; }
        public int GroupsId { get; set; }

        public List<ExameViewModel> ExameList { get; set; }
        public int ContaTotal { get; set; }
        public IEnumerable<Groups> GroupsList { get; set; }

        public ExameViewModel(Exame model)
        {
            Id = model.Id;
            Titulo = model.Titulo ?? "";
            Descricao = model.Descricao ?? "";
            DataInicio = model.DataInicio;
            Hora = model.Hora;
            GroupsId = model.GroupsId;
        }

        public Exame ConvertExameViewModel(ExameViewModel vm)
        {
            return new Exame
            {
                Id = vm.Id,
                Titulo = vm.Titulo ?? "",
                Descricao = vm.Descricao ?? "",
                DataInicio = vm.DataInicio,
                Hora = vm.Hora,
                GroupsId = vm.GroupsId,
            };
        }

        public ExameViewModel()
        {

        }
    }
}
