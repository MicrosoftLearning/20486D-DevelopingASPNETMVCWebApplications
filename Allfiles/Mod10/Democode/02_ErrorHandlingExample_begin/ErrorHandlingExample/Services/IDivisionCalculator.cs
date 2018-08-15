using ErrorHandlingExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingExample.Services
{
    public interface IDivisionCalculator
    {
        DivisionResult GetDividedNumbers(int number);
    }
}
