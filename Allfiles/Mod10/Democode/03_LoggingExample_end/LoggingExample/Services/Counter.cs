using Microsoft.Extensions.Logging;
using Serilog.Core;
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
            {
                _logger.LogDebug($"Increasing the counter to the {requestPath} key.");
                UrlCounter[requestPath]++;
            }
            else
            {
                _logger.LogDebug($"Adding the new key {requestPath} to the counter dictionary.");
                UrlCounter.Add(requestPath, 1);
            }
        }
    }
}
