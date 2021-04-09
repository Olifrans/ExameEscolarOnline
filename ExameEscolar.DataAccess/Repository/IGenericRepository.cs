using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using NPOI.SS.Formula.Functions;



namespace ExameEscolar.DataAccess.Repository
{
    public interface IGenericRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderBy = null,
            String includeProperties = "");


        T GetByID(object id);
        Task<T> GetByIdAsync(object id);

        void Add(T entity);
        Task<T> AddAsync(T entity);

        void DeleteByID(object id);
        void DeleteByID(T entityToDelete);
        Task<T> DeleteAsync(T entityToDelete);

        void Update(T entityToUpdate);
        Task<T> UpdateAsync(T entityToUpdate);
    }
}
