using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ConfigureServiceExample.Services
{
    public class Logger : ILogger
    {
        string _filename;
        public Logger()
        {
            _filename = $"{DateTime.Now.ToString("yyyy-dd-MM--HH-mm-ss")}.log";
        }

        public void Log(string logData)
        {
            File.AppendAllText(_filename, $"{DateTime.UtcNow}: {logData}");
        }
    }
}
