using System;

namespace GoF_Strategie_Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Formel eingeben:");
            string eingabe = Console.ReadLine(); // "2 + 2"

            string[] operanden = eingabe.Split('+');
            int zahl1 = Convert.ToInt32(operanden[0]);
            int zahl2 = Convert.ToInt32(operanden[1]);

            Console.WriteLine($"Das Ergebnis is {zahl1 + zahl2}");

            Console.WriteLine("---Ende---");
            Console.ReadKey();
        }
    }
}
