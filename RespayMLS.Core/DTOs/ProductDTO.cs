using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class ProductDTO
    {
        public int CurrencyId { get; set; }

        public int CategoryId { get; set; }

        public int PlanTypeId { get; set; }

        public int FrequencyId { get; set; }

        public int SectorId { get; set; }

        public double Amount { get; set; }

        public double SetupFee { get; set; }

        public double MaximumListing { get; set; }

        public string ProductName { get; set; }
    }
}
