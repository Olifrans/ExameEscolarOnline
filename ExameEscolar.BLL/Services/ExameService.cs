using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExameEscolar.DataAccess.UnitOfWork;
using ExameEscolar.ViewModels;
using ExameEscolar.DataAccess;
using Microsoft.Extensions.Logging;

namespace ExameEscolar.BLL.Services
{
    public class ExameService : IExameService
    {
        IUnitOfWork _unitOfWork;
        ILogger<ExameViewModel> _ILogger;

        public ExameService(IUnitOfWork unitOfWork, ILogger<ExameViewModel> iLogger)
        {
            _unitOfWork = unitOfWork;
            _ILogger = iLogger;
        }

        public async Task<ExameViewModel> AddExameAsync(ExameViewModel exameVM)
        {
            try
            {
                Exame objExame = exameVM.ConvertExameViewModel(exameVM);
                await _unitOfWork.GenericRepository<Exame>().AddAsync(objExame);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return null;
            }
            return exameVM;
        }

        public PaginaDeResultado<ExameViewModel> GetAllExame(int PaginaNumero, int PaginaTamanho)
        {
            var model = new ExameViewModel();
            try
            {
                int ExcludeRecords = (PaginaTamanho * PaginaNumero) - PaginaNumero;
                List<ExameViewModel> detalheList = new List<ExameViewModel>();
                var modelList = _unitOfWork.GenericRepository<Exame>().GetAll().Skip(ExcludeRecords).Take(PaginaTamanho).ToList();
                var contaTotal = _unitOfWork.GenericRepository<Exame>().GetAll().ToList();

                detalheList = ExameListInfo(modelList);

                if (detalheList != null)
                {
                    model.ExameList = detalheList;
                    model.ContaTotal = contaTotal.Count();
                }
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            var resultado = new PaginaDeResultado<ExameViewModel>
            {
                Data = model.ExameList,
                TotalItems = model.ContaTotal,
                PaginaNumero = PaginaNumero,
                PaginaTamanho = PaginaTamanho,
            };
            return resultado;
        }

        private List<ExameViewModel> ExameListInfo(List<Exame> modelList)
        {
            return modelList.Select(o => new ExameViewModel(o)).ToList();
        }

        public IEnumerable<Exame> GetAllExame()
        {
            try
            {
                var exame = _unitOfWork.GenericRepository<Exame>().GetAll();
                return exame;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return Enumerable.Empty<Exame>();
        }
    }
}
