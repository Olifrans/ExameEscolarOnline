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
    public class QnAsService : IQnAsService
    {
        IUnitOfWork _unitOfWork;
        ILogger<QnAsViewModel> _ILogger;

        public QnAsService(IUnitOfWork unitOfWork, ILogger<QnAsViewModel> iLogger)
        {
            _unitOfWork = unitOfWork;
            _ILogger = iLogger;
        }

        public async Task<QnAsViewModel> AddExameAsync(QnAsViewModel QnAVM)
        {
            try
            {
                QnAs objQnAs = QnAVM.ConvertQnAsViewModel(QnAVM);
                await _unitOfWork.GenericRepository<QnAs>().AddAsync(objQnAs);
                _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                return null;
            }
            return QnAVM;
        }

        public PaginaDeResultado<QnAsViewModel> GetAllExame(int paginaNumero, int paginaTamanho)
        {
            var model = new QnAsViewModel();
            try
            {
                int ExcludeRecords = (paginaTamanho * paginaNumero) - paginaNumero;
                List<QnAsViewModel> detalheList = new List<QnAsViewModel>();
                var modelList = _unitOfWork.GenericRepository<QnAs>().GetAll()
                    .Skip(ExcludeRecords).Take(paginaTamanho).ToList();
                var contaTotal = _unitOfWork.GenericRepository<QnAs>().GetAll().ToList();

                detalheList = ListInfo(modelList);
                if (detalheList != null)
                {
                    model.QnAsList = detalheList;
                    model.ContaTotal = contaTotal.Count();
                }
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            var resultado = new PaginaDeResultado<QnAsViewModel>
            {
                Data = model.QnAsList,
                TotalItems = model.ContaTotal,
                PaginaNumero = paginaNumero,
                PaginaTamanho = paginaTamanho,
            };
            return resultado;
        }

        private List<QnAsViewModel> ListInfo(List<QnAs> modelList)
        {
            return modelList.Select(o => new QnAsViewModel(o)).ToList();
        }

        public IEnumerable<QnAsViewModel> GetAllQnAByExame(int exameId)
        {
            try
            {
                var qnaList = _unitOfWork.GenericRepository<QnAs>()
                    .GetAll().Where(x => x.ExameId == exameId);
                return ListInfo(qnaList.ToList());
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return Enumerable.Empty<QnAsViewModel>();
        }

        public bool IsExameAttendet(int exameId, int estudanteId)
        {
            try
            {
                var qnaRecord = _unitOfWork.GenericRepository<ExameResultado>().GetAll()
                    .FirstOrDefault(x => x.ExameId == exameId && x.EstudanteId == estudanteId);
                return qnaRecord == null ? false : true;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return false;
        }
    }
}
