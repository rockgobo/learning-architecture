using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.data.ef
{
    public class BookShopRepository : EFBaseUnitOfWorkRepository<BookShop>, IBookShopRepository
    {
        public BookShopRepository(EFContext context) : base(context) { }

        public BookShop GetBookShopWithMostInventoryValue()
        {
            throw new NotImplementedException();
        }
    }
}
