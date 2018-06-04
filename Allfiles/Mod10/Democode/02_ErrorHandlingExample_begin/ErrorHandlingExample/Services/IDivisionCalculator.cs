using ErrorHandlingExample.Models;

namespace ErrorHandlingExample.Services
{
    public interface IDivisionCalculator
    {
        DivisionResult GetDividedNumbers(int number);
    }
}