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

            if (core.Repository.GetAll<BookShop>().Count() == 0)
                core.GenerateDemoData();

            foreach (var shop in core.Repository.GetAll<BookShop>())
            {
                Console.WriteLine($"[{shop.Name}] - Standort: {shop.Address}");
                foreach (var stock in shop.Inventory)
                    Console.WriteLine($"[{shop.Name}] - Buch: {stock.Book.Title} - Anzahl: {stock.Amount}");
            }

            Console.WriteLine("--- Ende ---");
            Console.ReadKey();
        }
    }
}
