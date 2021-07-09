using ExameEscolar.DataAccess.UnitOfWork;
using ExameEscolar.ViewModels;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExameEscolar.DataAccess;



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

        public async Task<GroupsViewModel> AddGroupsAsync(GroupsViewModel groupVM)
        {
            try
            {
                Groups objGroups = groupVM.ConvertGroupsViewModel(groupVM);
                await _unitOfWork.GenericRepository<Groups>().AddAsync(objGroups);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return null;         
            }
            return groupVM;
        }

        public PaginaDeResultado<GroupsViewModel> GetAllGroups(int paginaNumero, int paginaTamanho)
        {
            var model = new GroupsViewModel();
            try
            {

                int ExcludeRecords = (paginaTamanho * paginaNumero) - paginaNumero;
                List<GroupsViewModel> detalheList = new List<GroupsViewModel>();
                var modelList = _unitOfWork.GenericRepository<Groups>().GetAll()
                    .Skip(ExcludeRecords).Take(paginaTamanho).ToList();
                var contaTotal = _unitOfWork.GenericRepository<Groups>().GetAll().ToList();

                detalheList = GroupListInfo(modelList);
                if (detalheList != null)
                {
                    model.GroupList = detalheList;
                    model.ContaTotal = contaTotal.Count();
                }
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            var resultado = new PaginaDeResultado<GroupsViewModel>
            {
                Data = model.GroupList,
                TotalItems = model.ContaTotal,
                PaginaNumero = paginaNumero,
                PaginaTamanho = paginaTamanho,
            };
            return resultado;

        }

        private List<GroupsViewModel> GroupListInfo(List<Groups> modelList)
        {
            return modelList.Select(o => new GroupsViewModel(o)).ToList();
        }

        public IEnumerable<Groups> GetAllGroups()
        {
            try
            {
                var groups = _unitOfWork.GenericRepository<Groups>().GetAll();
                return groups;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return Enumerable.Empty<Groups>();
        }

        public GroupsViewModel GetById(int groupId)
        {
            try
            {
                var group = _unitOfWork.GenericRepository<Groups>().GetByID(groupId);
                return new GroupsViewModel(group);
               
            }
            catch (Exception ex)
            {

                _ILogger.LogError(ex.Message);
            }
            return null;
        }
    }
}
