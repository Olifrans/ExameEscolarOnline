using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExameEscolar.DataAccess;
using ExameEscolar.ViewModels;



namespace ExameEscolar.BLL.Services
{
    public interface IExameService
    {
        PaginaDeResultado<ExameViewModel> GetAllExame(int paginaNumero, int paginaTamanho);

        Task<ExameViewModel> AddExameAsync(ExameViewModel exameVM);

        IEnumerable<Exame> GetAllExame();
    }
}
