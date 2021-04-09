using ExameEscolar.DataAccess;
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
    public class EstudanteService : IEstudanteService
    {
        IUnitOfWork _unitOfWork;
        ILogger<EstudanteService> _ILogger;

        public EstudanteService(IUnitOfWork unitOfWork, ILogger<EstudanteService> iLogger)
        {
            _unitOfWork = unitOfWork;
            _ILogger = iLogger;
        }

        public async Task<EstudanteViewModel> AddAsync(EstudanteViewModel vm)
        {
            try
            {
                Estudante objeto = vm.ConvertEstudanteViewModel(vm);
                await _unitOfWork.GenericRepository<Estudante>().AddAsync(objeto);

            }
            catch (Exception ex)
            {
                return null;
            }
            return vm;
        }

        public PaginaDeResultado<EstudanteViewModel> GetAll(int PaginaNumero, int PaginaTamanho)
        {
            var model = new EstudanteViewModel();
            try
            {
                int ExcludeRecords = (PaginaTamanho * PaginaNumero) - PaginaNumero;
                List<EstudanteViewModel> detalheList = new List<EstudanteViewModel>();
                var modelList = _unitOfWork.GenericRepository<Estudante>().GetAll().Skip(ExcludeRecords).Take(PaginaTamanho).ToList();
                var contaTotal = _unitOfWork.GenericRepository<Estudante>().GetAll().ToList();

                detalheList = GroupListInfo(modelList);

                if (detalheList != null)
                {
                    model.EstudanteList = detalheList;
                    model.ContaTotal = contaTotal.Count();
                }
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }

            var resultado = new PaginaDeResultado<EstudanteViewModel>
            {
                Data = model.EstudanteList,
                TotalItems = model.ContaTotal,
                PaginaNumero = PaginaNumero,
                PaginaTamanho = PaginaTamanho,
            };
            return resultado;
        }

        private List<EstudanteViewModel> GroupListInfo(List<Estudante> modelList)
        {
            return modelList.Select(o => new EstudanteViewModel(o)).ToList();
        }

        public IEnumerable<Estudante> GetAllEstudante()
        {
            try
            {
                var estudante = _unitOfWork.GenericRepository<Estudante>().GetAll();
                return estudante;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return Enumerable.Empty<Estudante>();
        }

        public IEnumerable<ResultadoViewModel> GetExameResultado(int estudanteId)
        {
            try
            {
                var exameResultado = _unitOfWork.GenericRepository<ExameResultado>().GetAll().Where(a => a.EstudanteId == estudanteId);
                var estudante = _unitOfWork.GenericRepository<Estudante>().GetAll();
                var exame = _unitOfWork.GenericRepository<Exame>().GetAll();
                var qnas = _unitOfWork.GenericRepository<QnAs>().GetAll();


                var requiredData = exameResultado.Join(estudante, er => er.EstudanteId, s => s.Id,
                (er, st) => new { er, st }).Join(exame, erj => erj.er.ExameId, ex => ex.Id,
                (erj, ex) => new { erj, ex }).Join(qnas, exj => exj.erj.er.QnAsId, q => q.Id,
                (exj, q) => new ResultadoViewModel()
                {
                    EstudanteId = estudanteId,
                    ExameNome = exj.ex.Titulo,

                    TotalDeQuestoes = exameResultado.Count(a => a.EstudanteId == estudanteId
                    && a.ExameId == exj.ex.Id),
                    RespostaCorreta = exameResultado.Count(a => a.EstudanteId == estudanteId && a.ExameId == exj.ex.Id && a.Responder == q.Responder),
                    RespostaErrada = exameResultado.Count(a => a.EstudanteId == estudanteId &&
                    a.ExameId == exj.ex.Id && a.Responder != q.Responder)
                });

                return requiredData;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return Enumerable.Empty<ResultadoViewModel>();
        }

        public EstudanteViewModel GetEstudanteDetalhes(int estudanteId)
        {
            try
            {
                var estudante = _unitOfWork.GenericRepository<Estudante>().GetByID(estudanteId);
                return estudante != null ? new EstudanteViewModel(estudante) : null;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return null;
        }

        public bool SetExameResultado(AtendeExameViewModel vm)
        {
            try
            {
                foreach (var item in vm.QnAs)
                {
                    ExameResultado exameResultado = new ExameResultado();
                    exameResultado.EstudanteId = vm.EstudanteId;
                    exameResultado.QnAsId = item.Id;
                    exameResultado.ExameId = item.ExameId;
                    exameResultado.Responder = item.Responder;
                    _unitOfWork.GenericRepository<ExameResultado>().AddAsync(exameResultado);
                }
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return false;
        }

        public bool SetGroupIdToEstudante(GroupsViewModel vm)
        {
            try
            {
                foreach (var item in vm.estudanteChecks)
                {
                    var estudante = _unitOfWork.GenericRepository<Estudante>().GetByID(item.Id);

                    if (item.Selected)
                    {
                        estudante.GroupsId = vm.Id;
                        _unitOfWork.GenericRepository<Estudante>().Update(estudante);
                    }
                    else
                    {
                        if (estudante.GroupsId == vm.Id)
                        {
                            estudante.GroupsId = null;
                        }
                    }
                    _unitOfWork.Save();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _ILogger.LogError(ex.Message);
            }
            return false;

        }

        public async Task<EstudanteViewModel> UpdateAsync(EstudanteViewModel vm)
        {
            try
            {
                Estudante objeto = _unitOfWork.GenericRepository<Estudante>().GetByID(vm.Id);
                objeto.Nome = vm.Nome;
                objeto.UsuarioNome = vm.UsuarioNome;
                objeto.ImagemNomeArquivo = vm.ImagemNomeArquivo != null ? vm.ImagemNomeArquivo : objeto.ImagemNomeArquivo;
                objeto.CVNomeArquivo = vm.CVNomeArquivo != null ? vm.CVNomeArquivo : objeto.CVNomeArquivo;
                objeto.Contato = vm.Contato;
                await _unitOfWork.GenericRepository<Estudante>().UpdateAsync(objeto);
                _unitOfWork.Save();
            }
            catch (Exception)
            {
                throw;
            }
            return vm;
        }
    }
}
