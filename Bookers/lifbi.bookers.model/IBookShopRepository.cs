using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    interface IBookShopRepository : IUnitOfWorkRepository<BookShop>
    {
        BookShop GetBookShopWithMostInventoryValue();
    }
}
