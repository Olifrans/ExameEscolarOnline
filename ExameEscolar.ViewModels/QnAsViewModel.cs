using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExameEscolar.DataAccess;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace ExameEscolar.ViewModels
{
    public class QnAsViewModel
    {      
        public int Id { get; set; }
        [Required]
        [Display(Name = "Exame")]
        public int ExameId { get; set; }
        [Required]
        [Display(Name = "Perguntas")]
        public string Pergunta { get; set; }
        [Required]
        [Display(Name = "Respostas")]
        public int Responder { get; set; }
        [Required]
        [Display(Name = "Opcao1")]
        public string Opcao1 { get; set; }
        [Required]
        [Display(Name = "Opcao2")]
        public string Opcao2 { get; set; }
        [Required]
        [Display(Name = "Opcao3")]
        public string Opcao3 { get; set; }
        [Required]
        [Display(Name = "Opcao4")]
        public string Opcao4 { get; set; }

        public List<QnAsViewModel> QnAsList { get; set; }
        public IEnumerable<Exame> ExameList { get; set; }
        public int ContaTotal { get; set; }
        public int SelecioneResposta { get; set; }

        public QnAsViewModel(QnAs model)
        {
            Id = model.Id;
            ExameId = model.ExameId;
            Pergunta = model.Pergunta ?? "";
            Opcao1 = model.Opcao1 ?? "";
            Opcao2 = model.Opcao2 ?? "";
            Opcao3 = model.Opcao3 ?? "";
            Opcao4 = model.Opcao4 ?? "";
            Responder = model.Responder;
        }

        public QnAs ConvertQnAsViewModel(QnAsViewModel vm)
        {
            return new QnAs
            {
                Id = vm.Id,
                ExameId = vm.ExameId,
                Pergunta = vm.Pergunta ?? "",
                Opcao1 = vm.Opcao1 ?? "",
                Opcao2 = vm.Opcao2 ?? "",
                Opcao3 = vm.Opcao3 ?? "",
                Opcao4 = vm.Opcao4 ?? "",
                Responder = vm.Responder,
            };
        }














        public QnAsViewModel()
        {

        }
    }
}
