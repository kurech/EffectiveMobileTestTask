using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EffectiveMobileTestTask.Logging
{
    public static class Logger
    {
        public static void Log(string message, string logFilePath)
        {
            var logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: {message}";

            try
            {
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка записи в логи: {ex.Message}");
            }
        }
    }
}
