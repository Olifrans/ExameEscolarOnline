using ExameEscolar.DataAccess;
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

        IEnumerable<Groups> GetAllGroups();

        GroupsViewModel GetById(int groupId);

    }
}
