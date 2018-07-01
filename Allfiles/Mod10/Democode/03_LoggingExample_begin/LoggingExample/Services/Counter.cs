using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

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
            NumberCounter[number]++;
        }
    }
}
