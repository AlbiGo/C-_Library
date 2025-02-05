using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.Strategy
{
    public class CalculateTaxPERC : CalculateTax, ICalculateTax
    {
        public void Calculate()
        {
            Console.WriteLine("Calculate tax PERC");
        }
    }
}