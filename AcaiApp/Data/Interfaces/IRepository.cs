using AcaiApp.Data.Context;
using AcaiApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcaiApp.Data.Interfaces
{
    public interface IRepository<TEntity> where TEntity: class, IEntity
    {
        public
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(int id);
    }
}
