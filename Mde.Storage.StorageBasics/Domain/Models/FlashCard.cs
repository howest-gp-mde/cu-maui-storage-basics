using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mde.Storage.StorageBasics.Domain.Models
{
    public class FlashCard
    {
        public string Question { get; set; }
        public List<Answer> Options { get; set; }
    }
}
