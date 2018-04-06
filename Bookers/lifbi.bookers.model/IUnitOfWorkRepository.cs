using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.model
{
    //Basis Interface für alle weiteren Repos
    public interface IUnitOfWorkRepository<T> where T : Entity
    {
        IEnumerable<T> GetAll() ;
        T GetByID(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Query();
        void Save();
    }
}
