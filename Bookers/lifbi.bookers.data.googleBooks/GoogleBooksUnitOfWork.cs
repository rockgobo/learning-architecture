using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.data.googleBooks
{
    class GoogleBooksUnitOfWork : IUnitOfWork
    {
        public IBookShopRepository BookShopRepository => throw new NotImplementedException();

        public IStockRepository StockRepository => throw new NotImplementedException();

        public IBooksRepository BooksRepository
        {
            get;
            set;
        }

        public IUnitOfWorkRepository<T> GetRepository<T>() where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
