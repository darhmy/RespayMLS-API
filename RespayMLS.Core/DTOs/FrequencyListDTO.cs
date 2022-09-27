using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class FrequencyListDTO
    {
        public int FrquencyId { get; set; }
        public string FrequencyName { get; set; }
        public string FrequencyTenure { get; set; }
        public int DaysInPeriod { get; set; }
    }
}
