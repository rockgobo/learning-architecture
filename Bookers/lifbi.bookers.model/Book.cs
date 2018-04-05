using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public class Book : Entity
    {
        public string Author {get; set;}
        public string Title { get; set; }
        public int Pages { get; set; }
        public decimal Price { get; set; }
    }
}
