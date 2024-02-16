using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Models
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
