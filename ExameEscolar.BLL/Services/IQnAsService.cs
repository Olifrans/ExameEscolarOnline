using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExameEscolar.DataAccess;
using ExameEscolar.ViewModels;

namespace ExameEscolar.BLL.Services
{
    public interface IQnAsService
    {
        PaginaDeResultado<QnAsViewModel> GetAllExame(int PaginaNumero, int PaginaTamanho);

        Task<QnAsViewModel> AddExameAsync(QnAsViewModel QnAVM);

        IEnumerable<QnAsViewModel> GetAllQnAByExame(int exameId);

        bool IsExameAttendet (int exameId, int estudanteId);
    }
}
