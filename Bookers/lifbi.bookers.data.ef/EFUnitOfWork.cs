using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.data.ef
{
    class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork()
        {
            context = new EFContext();
            repositories = new List<IUnitOfWorkRepository<Entity>>();
        }
        private readonly EFContext context;

        //BookShopRepository as singleton
        private object _syncObject = new object();
        private IBookShopRepository bookShopRepository;
        public IBookShopRepository BookShopRepository {
            get
            {
                if(bookShopRepository == null)
                {
                    lock (_syncObject)
                    {
                        bookShopRepository = bookShopRepository ?? new BookShopRepository(context);
                    }
                }
                return bookShopRepository;
            }
        }

        private List<IUnitOfWorkRepository<Entity>> repositories;

        public IUnitOfWorkRepository<T> GetRepository<T>() where T : Entity
        {
            if( repositories.Any(x => x.GetType() == typeof(IUnitOfWorkRepository<T>)) ){
                repositories.Add((IUnitOfWorkRepository<Entity>)new EFBaseUnitOfWorkRepository<T>(context));
            }
            return (IUnitOfWorkRepository<T>)repositories.First(x => x.GetType() == typeof(IUnitOfWorkRepository<T>));
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
