using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public interface IBookShopRepository : IUnitOfWorkRepository<BookShop>
    {
        BookShop GetBookShopWithMostInventoryValue();
    }
}
