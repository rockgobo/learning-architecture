﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GoF_Strategie_Taschenrechnerl
{
    class Program
    {
        static void Main(string[] args) //Bootstrapping
        {

            new ConsolenUI(
                new RegExParser(), 
                new EntkoppelterRechner(new Addition(), new Substraction(), new Multiplication())
            ).Start();

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

    class RegExParser : IParser
    {
        public Formel Parse(String input)
        {
            Formel output = new Formel();

            var match = Regex.Match(input,@"(\d+)\s*(\D)\s*(\d+)"); //TODO: regex

            output.Operand1 = Convert.ToInt32(match.Groups[1].Value);
            output.Operand2 = Convert.ToInt32(match.Groups[3].Value);
            output.Operator = match.Groups[2].Value[0];

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

    class EntkoppelterRechner : IRechner
    {
        public EntkoppelterRechner(params IRechenOperation[] operationen)
        {
            this.operationen = operationen;
        }
        private readonly IRechenOperation[] operationen;

        public int Rechne(Formel formel)
        {
            foreach(IRechenOperation o in operationen)
            {
                if(o.Operator == formel.Operator)
                {
                    return o.Berechne(formel);
                }
            }

            throw new ArgumentException("Operator unbekannt");
        }
    }

    interface IRechenOperation
    {
        char Operator { get; }
        int Berechne(Formel f);
    }

    class Addition : IRechenOperation
    {
        public char Operator => '+';

        public int Berechne(Formel f)
        {
            return f.Operand1 + f.Operand2;
        }
    }
    class Substraction : IRechenOperation
    {
        public char Operator => '-';

        public int Berechne(Formel f)
        {
            return f.Operand1 - f.Operand2;
        }
    }
    class Multiplication : IRechenOperation
    {
        public char Operator => '*';

        public int Berechne(Formel f)
        {
            return f.Operand1 * f.Operand2;
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
