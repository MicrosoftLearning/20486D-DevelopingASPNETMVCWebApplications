using LoggingExample.Models;

namespace LoggingExample.Services
{
    public interface IDivisionCalculator
    {
        DivisionResult GetDividedNumbers(int number);
    }
}