using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServiceExample
{
    public class ComplexCalculator : IComplexCalculator
    {
        public string ComplexCalculation()
        {
            return "Complex calculation result";
        }
    }
}
