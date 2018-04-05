using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.data.ef
{
    public class EFRepository : IRepository
    {
        public EFRepository(EFContext context) => this.context = context;
        private readonly EFContext context;

        public void Add<T>(T entity) where T : Entity
        {
            context.Set<T>().Add(entity);
        }

        public IEnumerable<T> GetAll<T>() where T : Entity
        {
            return context.Set<T>().ToList();
        }

        public T GetByID<T>(int id) where T : Entity
        {
            return context.Set<T>().Find(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update<T>(T entity) where T : Entity
        {
            var loaded = GetByID<T>(entity.ID);

            if(loaded != null)
            {
                context.Entry(loaded).CurrentValues.SetValues(entity);
            }
        }

        public void Delete<T>(T entity) where T : Entity
        {
            context.Set<T>().Remove(entity);
        }
    }
}
