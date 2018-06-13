using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingExample.Services
{
    public class Counter : ICounter
    {
        public Dictionary<string, int> UrlCounter { get; set; }
        private ILogger<Counter> _logger;


        public Counter(ILogger<Counter> logger)
        {
            UrlCounter = new Dictionary<string, int>();
            _logger = logger;
        }

        public void IncrementRequestPathCount(string requestPath)
        {
            if (UrlCounter.ContainsKey(requestPath))
                UrlCounter[requestPath]++;
            else
                UrlCounter.Add(requestPath, 1);
        }
    }
}
