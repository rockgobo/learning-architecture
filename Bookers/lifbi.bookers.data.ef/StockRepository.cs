using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lifbi.bookers.data.ef
{
    public class StockRepository : EFBaseUnitOfWorkRepository<Stock>, IStockRepository
    {
        public StockRepository(EFContext context) : base(context) { }

        public int GetAmountOfTotalBooksInCiruclation()
        {
            return GetAll().Sum(x => x.Amount);
        }
    }
}
