namespace Mde.Storage.StorageBasics.Core.Models
{
    public class LogEntry
    {
        public DateTime BrewTime { get; set; }
        public Coffee Coffee { get; set; }

        public override string ToString()
        {
            return $"{BrewTime.ToLocalTime().ToLongTimeString()} - {Coffee.Name}";
        }
    }
}
