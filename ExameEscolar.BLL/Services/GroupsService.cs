using ExameEscolar.DataAccess.UnitOfWork;
using ExameEscolar.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExameEscolar.BLL.Services
{
    public class GroupsService : IGroupsService
    {

        IUnitOfWork _unitOfWork;
        ILogger<GroupsService> _ILogger;

        public GroupsService(IUnitOfWork unitOfWork, ILogger<GroupsService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _ILogger = iLogger;
        }

        public Task<GroupsViewModel> AddGroupsAsync(GroupsViewModel groupVM)
        {
            throw new NotImplementedException();
        }

        public PaginaDeResultado<GroupsViewModel> GetAllGroups(int PaginaNumero, int PaginaTamanho)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GroupsViewModel> GetAllGroups()
        {
            throw new NotImplementedException();
        }

        public GroupsViewModel GetById(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}
