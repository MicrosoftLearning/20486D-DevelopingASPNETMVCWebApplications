using ErrorHandlingExample.Models;

namespace ErrorHandlingExample.Services
{
    public interface IPrimalNumberCalculator
    {
        DivisionResult GetDividedNumbers(int number);
    }
}