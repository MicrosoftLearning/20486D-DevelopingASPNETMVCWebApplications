using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace ConfigureServiceExample
{
    public class Logger : ILogger
    {
        string filename;
        public Logger()
        {
            filename = $"{DateTime.Now.ToString("yyyy-dd-MM--HH-mm-ss")}.log";
        }

        public void Log(string logData)
        {
            File.AppendAllText(filename, $"{DateTime.UtcNow}: {logData}");
        }
    }
}
