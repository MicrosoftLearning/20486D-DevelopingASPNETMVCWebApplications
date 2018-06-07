using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorHandlingExample.Models;

namespace ErrorHandlingExample.Services
{
    public interface IDivisionCalculator
    {
        DivisionResult GetDividedNumbers(int number);
    }
}