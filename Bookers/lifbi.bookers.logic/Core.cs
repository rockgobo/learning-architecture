using lifbi.bookers.model;
using lifbi.bookers.data.ef;
using System;

namespace lifbi.bookers.logic
{
    public class Core
    {
        //Construtor
        public Core(IRepository repository) => this.Repository = repository;
        public Core() : this(new EFRepository(new EFContext())) { }

        //Properties
        public IRepository Repository { get; set; }

        public void GenerateDemoData()
        {
            var bs1 = new BookShop();
            var bs2 = new BookShop();
            var bs3 = new BookShop();

            var b1 = new Book { Author = "Tom Ate", Title = "Mein eigenes Gewächshaus", Pages = 200, Price = 9.99m };
            var b2 = new Book { Author = "Anna Nass", Title = "Lexikon - Tropische Fruchtarten", Pages = 500, Price = 19.99m };
            var b3 = new Book { Author = "Peter Silie", Title = "Küchengewürze - Ratgeber", Pages = 50, Price = 5m };
            var b4 = new Book { Author = "Franz Ose", Title = "Reiseführer Paris", Pages = 25, Price = 2.99m };
            var b5 = new Book { Author = "Martha Pfahl", Title = "Abenteuer im wilden Westen", Pages = 250, Price = 29.50m };
            var b6 = new Book { Author = "Anna Bolika", Title = "Doping im Spitzensport", Pages = 150, Price = 15m };
            var b7 = new Book { Author = "Rainer Zufall", Title = "Neuronale Netzwerke und Zufallszahlgeneratoren", Pages = 2000, Price = 60m };
            var b8 = new Book { Author = "Bill Dung", Title = "Die Bildungsreform in Deutschland - Ein Trauerspiel in 3 Akten", Pages = 3, Price = 4.99m };
            var b9 = new Book { Author = "Dr. Frank N Stein", Title = "Anatomie des menschlichen Körpers", Pages = 666, Price = 6.66m };

            bs1.Name = "Der Bücherwurm";
            bs1.Address = "Hauptstraße 1";
            bs1.Inventory.Add(new Stock { Book = b1, Amount = 200 });
            bs1.Inventory.Add(new Stock { Book = b2, Amount = 50 });
            bs1.Inventory.Add(new Stock { Book = b3, Amount = 322 });

            bs2.Name = "Tee und Geschenkeecke";
            bs2.Address = "Marklerstraße 10";
            bs2.Inventory.Add(new Stock { Book = b4, Amount = 200 });
            bs2.Inventory.Add(new Stock { Book = b5, Amount = 50 });
            bs2.Inventory.Add(new Stock { Book = b6, Amount = 322 });

            bs3.Name = "Buchbasar";
            bs3.Address = "In der Büchnerstraße 5";
            bs3.Inventory.Add(new Stock { Book = b7, Amount = 200 });
            bs3.Inventory.Add(new Stock { Book = b8, Amount = 50 });
            bs3.Inventory.Add(new Stock { Book = b9, Amount = 322 });

            Repository.Add(bs1);
            Repository.Add(bs2);
            Repository.Add(bs3);
            Repository.Save();
        }
    }
}
