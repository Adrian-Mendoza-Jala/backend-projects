using System;
using System.IO;

namespace Class_8
{
    public static class Logger
    {
        public static void LogException(Exception ex)
        {
            string filePath = "exceptions.log";
            string messageToLog = $"Timestamp: {DateTime.Now}, Exception: {ex.GetType().Name}, Message: {ex.Message}{Environment.NewLine}";

            lock (filePath)
            {
                File.AppendAllText(filePath, messageToLog);
            }
        }
    }
}