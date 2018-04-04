using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Factory
{
    class Program
    {
        static void Main(string[] args)
        {

            var meinWirtshaus = new Cantina();

            var x = meinWirtshaus.GibEssen();

            x.Beschreibung();

            Console.WriteLine("--ENDE--");
            Console.ReadKey();
        }
    }
}
