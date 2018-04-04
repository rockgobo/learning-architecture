using System;

namespace GoF_Strategie_Taschenrechner
{
    class Program
    {
        static void Main(string[] args) //Bootstrapping
        {

            new ConsolenUI(new Parser(), new Rechner()).Start();

            Console.WriteLine("---Ende---");
            Console.ReadKey();
        }
    }

    class Formel
    {
        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public char Operator { get; set; }
    }

    interface IParser
    {
        Formel Parse(String input);
    }

    class Parser : IParser
    {
        public Formel Parse(String input) {
            Formel output = new Formel();
            string[] operanden = input.Split('+'); //TODO: regex

            output.Operand1 = Convert.ToInt32(operanden[0]);
            output.Operand2 = Convert.ToInt32(operanden[1]);
            output.Operator = '+';

            return output;
        }
    }

    interface IRechner
    {
        int Rechne(Formel formel);
    }

    class Rechner : IRechner
    {
        public int Rechne(Formel formel)
        {
            if(formel.Operator == '+')
            {
                return formel.Operand1 + formel.Operand2;
            }
            else if (formel.Operator == '-')
            {
                return formel.Operand1 - formel.Operand2;
            }
            else
            {
                throw new ArgumentException("Operator unbekannt");
            }
        }
    }

    class ConsolenUI{
        public ConsolenUI(IParser parser, IRechner rechner)
        {
            this.parser = parser;
            this.rechner = rechner;
        }


        private readonly IParser parser;
        private readonly IRechner rechner;

        public void Start()
        {
            Console.WriteLine("Formel eingeben:");
            string eingabe = Console.ReadLine(); // "2 + 2"
            
            Formel x = parser.Parse(eingabe);
            var ergebnis = rechner.Rechne(x);

            Console.WriteLine($"Das Ergebnis is {ergebnis}");

        }
    }
}
