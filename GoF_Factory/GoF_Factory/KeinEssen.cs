using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Factory
{
    class KeinEssen : IEssen
    {
        public void Beschreibung()
        {
            Console.WriteLine("Eier mit Speck");
        }
    }
}
