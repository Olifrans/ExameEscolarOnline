using System;
using System.Collections.Generic;
using System.Text;
using ExameEscolar.DataAccess.Repository;
using ExameEscolar.DataAccess.Data;
using Microsoft.EntityFrameworkCore;


namespace ExameEscolar.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;
        void Save();
    }
}
