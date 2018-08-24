using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoggingExample.Models;

namespace LoggingExample.Services
{
    public class DivisionCalculator : IDivisionCalculator
    {
        public DivisionResult GetDividedNumbers(int number)
        {
            DivisionResult divisionResult = new DivisionResult();

            divisionResult.DividedNumber = number;
            divisionResult.DividingNumbers = new List<int>();

            for (int i = 1; i < (number / 2) + 1; i++)
            {
                if (number % i == 0)
                {
                    divisionResult.DividingNumbers.Add(i);
                }
            }

            divisionResult.DividingNumbers.Add(number);

            return divisionResult;
        }
    }
}
