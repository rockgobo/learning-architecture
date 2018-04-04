using System;

namespace GoF_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var pizza = Pizza.Bäcker.mitKäse().mitSalami().mitSchinken().Generate();

            Console.WriteLine(pizza.Price);
            
            Console.WriteLine("--ENDE--");
            Console.ReadKey();
        }
    }
}
