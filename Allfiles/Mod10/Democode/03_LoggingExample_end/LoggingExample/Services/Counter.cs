using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingExample.Services
{
    public class Counter : ICounter
    {
        public Dictionary<int, int> NumberCounter { get; set; }
        private ILogger<Counter> _logger;


        public Counter(ILogger<Counter> logger)
        {
            NumberCounter = new Dictionary<int, int>();
            _logger = logger;
        }

        public void IncrementNumberCount(int number)
        {
            if (NumberCounter.ContainsKey(number))
            {
                NumberCounter[number]++;
                _logger.LogDebug($"The number of time the page was displayed for the number {number} was increased to {NumberCounter[number]}.");
            }
            else
            {
                NumberCounter.Add(number, 1);
                _logger.LogDebug($"The number {number} was added to the page display count dictionary");
            }
        }
    }
}
