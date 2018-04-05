using System;
using System.Collections.Generic;
using System.Text;

namespace lifbi.bookers.model
{
    public abstract class Entity
    {
        /// <summary>
        /// ID bewusst großgeschrieben, damit das Entity Framework es als Id erkennt
        /// </summary>
        public int ID { get; set; }
    }
}
