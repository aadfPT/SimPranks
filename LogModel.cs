using System;
using System.Configuration;
using System.IO;
using System.Text;
namespace SimPranks
{
    using System.Collections.Generic;

    internal static class LogModel
    {
        private static readonly object LogFileLock = new object();

        internal static void LogError(object sender, ErrorEventArgs e)
        {
            // Because the application is supposed to work invisibly, we are not showing the error to the user, and instead
            // write it to disk
            var output = new StringBuilder();
            var timeStamp = DateTime.UtcNow;
            output.AppendLine(
                $"{timeStamp.ToShortDateString()} {timeStamp.ToShortTimeString()} Error: {e.Description}");
            if (e.Exception == null)
            {
                output.AppendLine("No exception reported.");
            }
            else
            {
                var ex = e.Exception;
                while (ex != null)
                {
                    output.AppendLine(ex.GetType().FullName);
                    output.AppendLine("Message : " + ex.Message);
                    output.AppendLine("StackTrace : " + ex.StackTrace);
                    ex = ex.InnerException;
                }
            }
            var logFilename = ConfigurationManager.AppSettings["LogFilename"] ?? "ErrorsLog.txt";
            var logFilePath = Path.Combine(Environment.CurrentDirectory, logFilename);
            lock (LogFileLock)
            {
                File.AppendAllText(logFilePath, output.ToString());
            }
        }

        public static void LogMessage(string message)
        {
            var logFilename = ConfigurationManager.AppSettings["LogFilename"] ?? "ErrorsLog.txt";
            var logFilePath = Path.Combine(Environment.CurrentDirectory, logFilename);
            lock (LogFileLock)
            {
                File.AppendAllLines(logFilePath, new List<string> {message});
            }
        }
    }
}