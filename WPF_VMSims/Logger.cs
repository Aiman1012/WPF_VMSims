using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_VMSims
{
    public static class Logger
    {
        private static readonly string logDirectory = "Logs";
        private static readonly string logFileName = $"SessionLog_{DateTime.Now:yyyyMMdd_HHmmss}.txt";
        private static readonly string logFilePath;

        static Logger()
        {
            if (!Directory.Exists(logDirectory))
            {
                Directory.CreateDirectory(logDirectory);
            }
            logFilePath = Path.Combine(logDirectory, logFileName);

            // Optionally write a header when file is created
            File.WriteAllText(logFilePath, $"=== New Session Log - {DateTime.Now} ==={Environment.NewLine}");
        }

        public static void Log(string message)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}";
            File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
        }
    }
}
