using lifbi.bookers.logic;
using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lifbi.bookers.ui.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Core core = new Core();

            if (core.UnitOfWork.BookShopRepository.GetAll().Count() == 0)
                core.GenerateDemoData();

            foreach (var shop in core.UnitOfWork.GetRepository<BookShop>().GetAll())
            {
                Console.WriteLine($"[{shop.Name}] - Standort: {shop.Address}");
                foreach (var stock in shop.Inventory)
                    Console.WriteLine($"[{shop.Name}] - Buch: {stock.Book.Title} - Anzahl: {stock.Amount}");
            }

            var amazonLikeBookShop = core.UnitOfWork.BookShopRepository.GetBookShopWithMostInventoryValue();
            Console.WriteLine("Dieser Händler hat am meisten Bücher: {0} mit {1} Euro", amazonLikeBookShop.Name, amazonLikeBookShop.Inventory.Sum(i => i.Amount * i.Book.Price));

            Console.WriteLine("Anzahl der Bücher im Umlauf: {0} ", core.UnitOfWork.StockRepository.GetAmountOfTotalBooksInCiruclation());

            Console.WriteLine("Anzahl der Bücher von Google: {0} ", core.UnitOfWork.BooksRepository.GetAll().Count());


            Console.WriteLine("--- Ende ---");
            Console.ReadKey();
        }
    }
}
