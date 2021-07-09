using ExameEscolar.DataAccess.UnitOfWork;
using ExameEscolar.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExameEscolar.DataAccess;
using Microsoft.Extensions.Logging;


namespace ExameEscolar.BLL.Services
{
    public class AccountService : IAccountService
    {
        IUnitOfWork _unitOfWork;
        ILogger<EstudanteService> _ILogger;

        public AccountService(IUnitOfWork unitOfWork, ILogger<EstudanteService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _ILogger = iLogger;
        }

        public bool AddProfessor(UsuarioViewModel vm)
        {
            try
            {
                Usuario objeto = new Usuario()
                {
                    Nome = vm.Nome,
                    UsuarioNome = vm.UsuarioNome,
                    Senha = vm.Senha,
                    Funcao = (int)EnumFuncoes.Professor,

                };
                _unitOfWork.GenericRepository<Usuario>().AddAsync(objeto);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
                return false;
            }        
            return true;
        }

        public PaginaDeResultado<UsuarioViewModel> GetAllProfessor(int paginaNumero, int paginaTamanho)
        {
            var model = new UsuarioViewModel();
            try
            {
                int ExcludeRecords = (paginaTamanho * paginaNumero) - paginaTamanho;
                List<UsuarioViewModel> detalheList = new List<UsuarioViewModel>();
                var modelList = _unitOfWork.GenericRepository<Usuario>().GetAll()
                    .Where(x => x.Funcao == (int)EnumFuncoes.Professor).Skip(ExcludeRecords)
                    .Take(paginaTamanho).ToList();

                detalheList = ListInfo(modelList);

                if (detalheList !=null)
                {
                    model.UsuarioList = detalheList;
                    model.ContaTotal = _unitOfWork.GenericRepository<Usuario>().GetAll()
                        .Count(x => x.Funcao == (int)EnumFuncoes.Professor);
                }
            }
            catch (Exception ex)
            {

                _ILogger.LogError(ex.Message);
            }
            var resultado = new PaginaDeResultado<UsuarioViewModel>
            {
                Data = model.UsuarioList,
                TotalItems = model.ContaTotal,
                PaginaNumero = paginaNumero,
                PaginaTamanho = paginaTamanho,
            };
            return resultado;

        }

        private List<UsuarioViewModel> ListInfo(List<Usuario> modelList)
        {
            return modelList.Select(o => new UsuarioViewModel(o)).ToList();
        }

        public LoginViewModel Login(LoginViewModel vm)
        {
            if (vm.Funcao == (int)EnumFuncoes.Admin || vm.Funcao == (int)EnumFuncoes.Professor)
            {

                var usuario = _unitOfWork.GenericRepository<Usuario>().GetAll().
                    FirstOrDefault(a => a.UsuarioNome == vm.UsuarioNome.Trim() &&
                    a.Senha == vm.Senha.Trim() && a.Funcao == vm.Funcao);

                if (usuario != null)
                {
                    vm.Id = usuario.Id;
                    return vm;
                }
            }
            else
            {
                var estudante = _unitOfWork.GenericRepository<Usuario>().GetAll().
                    FirstOrDefault(a => a.UsuarioNome == vm.UsuarioNome.Trim()
                    && a.Senha == vm.Senha.Trim());

                if (estudante != null)
                {
                    vm.Id = estudante.Id;
                    return vm;
                }
            }
            return null;
        }
    }
}
