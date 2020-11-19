using System;
using Calc.Lib;

namespace CalcProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.Write("Enter Data:");
            var data = Console.ReadLine();
            Console.Write("Enter D for decimal H for Hex :");
            string numberBase = Console.ReadLine();
            bool married = true;

            ICalculationEngine calulatorEngine = ((numberBase == "H") ? new HexEngine() : new DecimalEngine());

            if (numberBase.Equals("H"))
                calulatorEngine = new HexEngine();
            else
                calulatorEngine = new DecimalEngine();

            var calc = new Calculator(numberBase.Equals("H") ? new HexEngine() : new DecimalEngine());

            var result = calc.Add(data);
            Console.WriteLine($">>> {result}");

        }
    }
}
