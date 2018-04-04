using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoF_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Schrank schrank1 = Schrank.Schrankbauer()
                .MitBöden(3)
                .MitOberfläche(Schrank.OberflächenArt.Lackiert)
                .MitFarbe("Rot")
                .MitKleiderstange(true)
                .MitTüren(4)
                .MitMetallschienen(true)
                .Konstruieren();

            //Schrank mit Exception
            try
            {
                Schrank schrank2 = Schrank.Schrankbauer()
                    .MitBöden(3)
                    .MitOberfläche(Schrank.OberflächenArt.Gewachst)
                    .MitFarbe("Rot")
                    .Konstruieren();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("--ENDE--");
            Console.ReadKey();
        }
    }
}
