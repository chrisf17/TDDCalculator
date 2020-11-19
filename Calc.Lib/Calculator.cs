using System;
using System.Linq;
namespace Calc.Lib
{
    public interface ICalculationEngine
    {
        string Add(string z1, string z2);
    }
    public class DecimalEngine: ICalculationEngine
    {
        public string Add(string d1, string d2)
        {
            return (int.Parse(d1) + int.Parse(d2)).ToString();
        }
    }
    public class HexEngine : ICalculationEngine
    {
        public string Add(string h1, string h2)
        {
            var p1 = int.Parse(h1, System.Globalization.NumberStyles.HexNumber);
            var p2 = int.Parse(h2, System.Globalization.NumberStyles.HexNumber);
            var result = p1 + p2;
            return result.ToString("X");
        }
    }

    public class Calculator
    {
        ICalculationEngine calc;
        public Calculator(ICalculationEngine calc)
        {
            this.calc = calc;
        }
        public string Add(string data)
        {
            string retVal;
            var values = data.Split(',');
            if (values.Length == 1)
            {
                int.TryParse(values[0], out int result);
                retVal = result.ToString();
            }
            else
            {
                string total = "0";
                values.ToList().ForEach(a =>
                {
                    total = calc.Add(total, a);
                });
                retVal = total;
            }
            

            return retVal;
        }
    }
}
