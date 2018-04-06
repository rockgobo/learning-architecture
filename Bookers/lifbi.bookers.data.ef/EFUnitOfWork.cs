using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.data.ef
{
    public class EFUnitOfWork : IUnitOfWork
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

        private IStockRepository stockRepository;
        public IStockRepository StockRepository
        {
            get
            {
                if (stockRepository == null)
                {
                    lock (_syncObject)
                    {
                        stockRepository = stockRepository ?? new StockRepository(context);
                    }
                }
                return stockRepository;
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
