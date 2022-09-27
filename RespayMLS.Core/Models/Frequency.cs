using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class Frequency
    {
        public int FrequencyId { get; set; }
        public string FrequencyName { get; set; }
        public string FrequencyTenure { get; set; }
        public int DaysInPeriod { get; set; }

        public ICollection<Charge> Charges { get; set; }
    }
}
