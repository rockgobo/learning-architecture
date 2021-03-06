﻿using lifbi.bookers.model;
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
            return GetAll()
                    .Select(x => (Shop: x, Total: x.Inventory.Sum(i => i.Amount * i.Book.Price)))
                    .OrderByDescending(x => x.Total)
                    .First()
                    .Shop;
        }

        public int GetTotalNumberOfBooks(BookShop shop)
        {
            return shop.Inventory.Sum(i => i.Amount);
        }
    }
}
