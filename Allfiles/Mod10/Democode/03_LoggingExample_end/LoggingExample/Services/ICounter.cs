using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoggingExample.Services
{
    public interface ICounter
    {
        Dictionary<int, int> NumberCounter { get; set; }
        void IncrementNumberCount(int requestPath);
    }
}
