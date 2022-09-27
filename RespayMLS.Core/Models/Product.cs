using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public double MaximumListing { get; set; }

        public double Amount { get; set; }

        public double SetupFee { get; set; }

        /// <summary>
        /// Web, Mobile
        /// </summary>
        //public string ChannelType { get; set; }

        public Frequency Frequency { get; set; }

        public Currency Currency { get; set; }

        public PlanType PlanType { get; set; }

        public Sector Sector { get; set; }

        public ProductCategory ProductCategory { get; set; }

    }
}
