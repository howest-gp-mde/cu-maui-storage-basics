using Mde.Storage.StorageBasics.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Services
{
    public interface ICoffeeLoggingService
    {
        void Log(Coffee coffee);
        IEnumerable<LogEntry> GetLogs();
    }
}
