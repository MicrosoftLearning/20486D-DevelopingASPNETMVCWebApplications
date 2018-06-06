using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingExample.Models
{
    public class DivisionResult
    {
        public int DividedNumber { get; set; }

        public List<int> DividingNumbers {get;set;}
        
        public override string ToString()
        {
            StringBuilder bld = new StringBuilder();

            foreach (int currentNumber in DividingNumbers)
            {
                bld.Append($"{currentNumber} ,");
            }
            bld.Remove(bld.Length - 1, 1);

            return bld.ToString();
        }

    }
}
