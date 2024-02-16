using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Models
{
    public class Coffee
    {
        public string Name { get; set; }
        public CoffeeConfiguration Configuration { get; set; }
    }
}
