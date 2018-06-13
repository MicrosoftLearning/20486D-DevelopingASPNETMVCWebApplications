using LoggingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingExample.Services
{
    public interface IDivisionCalculator
    {
        DivisionResult GetDividedNumbers(int number);
    }
}
