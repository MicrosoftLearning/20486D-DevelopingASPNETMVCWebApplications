using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorHandlingExample.Services
{
    public interface ICounter
    {
        Dictionary<string, int> UrlCounter { get; set; }
        void IncrementRequestPathCount(string requestPath);
    }
}
