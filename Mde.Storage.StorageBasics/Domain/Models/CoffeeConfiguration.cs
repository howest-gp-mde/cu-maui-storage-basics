using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Models
{
    public class CoffeeConfiguration
    {
        public int Water { get; set; }
        public int Coffee { get; set; }
        public int Milk { get; set; }
        public int Foam { get; set; }
        public int Pressure { get; set; }
        public int Temperature { get; set; }
    }
}
