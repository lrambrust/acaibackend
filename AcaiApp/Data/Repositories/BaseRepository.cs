using AcaiApp.Data.Context;
using AcaiApp.Data.Interfaces;
using AcaiApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AcaiApp.Data.Repositories
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        protected readonly AcaiContext _context;

        public BaseRepository(AcaiContext context)
        {
            _context = context;
        }

        public virtual void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }

        public TEntity Get(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

    }
}
