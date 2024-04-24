using Mde.Storage.StorageBasics.Core.Models;
using System.Text.Json;

namespace Mde.Storage.StorageBasics.Core.Services
{
    public class LocalLoggingService : ICoffeeLoggingService
    {
        const string filename = "brews.log";
        static string logfilePath = Path.Combine(FileSystem.Current.AppDataDirectory, filename);

        /// <summary>
        /// Returns all logs from the log file
        /// </summary>
        public IEnumerable<LogEntry> GetLogs()
        {
            if (File.Exists(logfilePath))
            {
                string[] logEntries = File.ReadAllLines(logfilePath);
                if (logEntries == null) return [];

                //Log files typically store entries line per line.
                //In this case they are single json objects so we need to wrap them in an array.
                string joinedEntries = $"[{logEntries.Aggregate((current, next) => $"{current},{next}")}]";
                return JsonSerializer.Deserialize<List<LogEntry>>(joinedEntries);
            }
            else
            {
                return new List<LogEntry>();
            }
        }

        public void Log(Coffee coffee)
        {
            var directory = Path.GetDirectoryName(logfilePath);
            Directory.CreateDirectory(directory);

            var newLog = new LogEntry { BrewTime = DateTime.UtcNow, Coffee = coffee };
            var logEntry = JsonSerializer.Serialize(newLog);

            //write the entry on a new line, directly in the log file
            File.AppendAllLines(logfilePath, [logEntry]);
        }

        public void Clear()
        {
            if (File.Exists(logfilePath)) File.Delete(logfilePath);
        }

    }
}
