using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.data.ef
{
    public class EFBaseUnitOfWorkRepository<T> : IUnitOfWorkRepository<T> where T : Entity
    {
        public EFBaseUnitOfWorkRepository(EFContext context) => this.context = context;
        private readonly EFContext context;

        public virtual void Add(T entity) 
        {
            context.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> GetAll() 
        {
            return context.Set<T>().ToList();
        }

        public virtual T GetByID(int id)
        { 
            return context.Set<T>().Find(id);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual void Update(T entity) 
        {
            var loaded = GetByID(entity.ID);

            if (loaded != null)
            {
                context.Entry(loaded).CurrentValues.SetValues(entity);
            }
        }

        public virtual void Delete(T entity) 
        {
            context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> Query() 
        {
            return context.Set<T>();
        }
    }
}
