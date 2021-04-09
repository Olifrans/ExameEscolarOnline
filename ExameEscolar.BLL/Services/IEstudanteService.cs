using ExameEscolar.DataAccess;
using ExameEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.BLL.Services
{
    public interface IEstudanteService
    {
        PaginaDeResultado<EstudanteViewModel> GetAll(int PaginaNumero, int PaginaTamanho);

        Task<EstudanteViewModel> AddAsync(EstudanteViewModel vm);

        IEnumerable<Estudante> GetAllEstudante();

        bool SetGroupIdToEstudante(GroupsViewModel vm);

        bool SetExameResultado(AtendeExameViewModel vm);

        IEnumerable<ResultadoViewModel> GetExameResultado(int estudanteId);

        EstudanteViewModel GetEstudanteDetalhes(int estudanteId);

        Task<EstudanteViewModel> UpdateAsync(EstudanteViewModel vm);

    }   
}
