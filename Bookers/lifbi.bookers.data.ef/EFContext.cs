using lifbi.bookers.model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace lifbi.bookers.data.ef
{
    /// <summary>
    /// Konfiguration für Entity Framework 
    /// </summary>
    public class EFContext : DbContext
    {
        /// <summary>
        /// Konstruktor für lokalen SQL Server
        /// </summary>
        public EFContext() : this("Server=.;Database=Bookers;Trusted_Connection=true") { }

        // <summary>
        // Konstruktor für Localdb
        // </summary>
        // public EFContext() : this("Server=(localdb)\\mssqllocaldb;Database=Bookers;Trusted_Connection=true;AttachedFilename:C:\\temp\\bookers.mdf") { }
        
        /// <summary>
        /// Konstruktor mit Connectionstring als Übergabe
        /// </summary>
        /// <param name="connectionstring"></param>
        public EFContext(string connectionstring) : base(connectionstring) { }

        public DbSet<Book> Book { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<BookShop> BookShop { get; set; }
    }
}
