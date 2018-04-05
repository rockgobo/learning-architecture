using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T : Entity;
        T GetByID<T>(int id) where T : Entity;
        void Add<T>(T entity) where T : Entity;
        void Update<T>(T entity) where T : Entity;
        void Save();
    }
}
