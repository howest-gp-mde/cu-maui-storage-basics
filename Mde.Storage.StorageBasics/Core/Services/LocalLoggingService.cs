using Mde.Storage.StorageBasics.Core.Models;
using System.Text.Json;

namespace Mde.Storage.StorageBasics.Core.Services
{
    public class LocalLoggingService : ICoffeeLoggingService
    {
        const string filename = "logs.json";
        static string logfilePath = Path.Combine(FileSystem.Current.AppDataDirectory, filename);

        public IEnumerable<LogEntry> GetLogs()
        {
            if (File.Exists(logfilePath))
            {
                var content = File.ReadAllText(logfilePath);
                return JsonSerializer.Deserialize<List<LogEntry>>(content);
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
            var logs = (List<LogEntry>)GetLogs();
            logs.Add(newLog);

            var serializedLogs = JsonSerializer.Serialize(logs);

            File.WriteAllText(logfilePath, serializedLogs);
        }

        public void Clear()
        {
            if (File.Exists(logfilePath)) File.Delete(logfilePath);
        }

    }
}
