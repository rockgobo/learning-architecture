using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.data.ef
{
    class EFUnitOfWork : IUnitOfWork
    {
        public EFUnitOfWork()
        {
            context = new EFContext();
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

        public IUnitOfWorkRepository<T> GetRepository<T>() where T : Entity
        {
            return new EFBaseUnitOfWorkRepository<T>(context);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
