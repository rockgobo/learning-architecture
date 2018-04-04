using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger.Instance.Log("Hallo 1");
            Logger.Instance.Log("Hallo 2");
            Logger.Instance.Log("Hallo 3");

            Parallel.For(0, 1000, i => Logger.Instance.Log($"Hallo von {i}"));


            Console.WriteLine("ENDE");
            Console.ReadKey();
        }
    }
}
