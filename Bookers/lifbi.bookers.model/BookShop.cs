using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public class BookShop : Entity
    {
        public string Name { get; set; }
        public string Address { get; set; }

        /// <summary>
        /// Implementations Kommentar:
        /// "virtual" weil EF dann einen eigenen getter implementieren kann
        /// "HashSet" damit EF keine doppelten Einträge lädt.
        /// </summary>
        public virtual HashSet<Stock> Inventory { get; set; }
    }
}
