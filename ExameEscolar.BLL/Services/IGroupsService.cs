using ExameEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.BLL.Services
{
    public interface IGroupsService
    {
        PaginaDeResultado<GroupsViewModel> GetAllGroups(int PaginaNumero, int PaginaTamanho);

        Task<GroupsViewModel> AddGroupsAsync(GroupsViewModel groupVM);

        IEnumerable<GroupsViewModel> GetAllGroups();

        GroupsViewModel GetById(int groupId);


        //bool SetGroupIdToEstudante(GroupsViewModel vm);

        //bool SetExameResultado(AtendeExameViewModel vm);

        //IEnumerable<ResultadoViewModel> GetExameResultado(int estudanteId);

        //EstudanteViewModel GetEstudanteDetalhes(int estudanteId);

        //Task<EstudanteViewModel> UpdateAsync(EstudanteViewModel vm);
    }
}
