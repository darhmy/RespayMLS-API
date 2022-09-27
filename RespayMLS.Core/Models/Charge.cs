using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class Charge
    {
        public int ChargeId { get; set; }

        public double Amount { get; set; }

        public double SetupFee { get; set; }

        public Frequency Frequency { get; set; }

        public Currency Currency { get; set; }

        public ICollection<Product> Products { get; set; }

    }
}
