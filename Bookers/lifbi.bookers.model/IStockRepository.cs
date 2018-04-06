using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public interface IStockRepository : IUnitOfWorkRepository<Stock>
    {
        int GetAmountOfTotalBooksInCiruclation();
    }
}
