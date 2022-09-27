using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class ItemSubFeature
    {
        public int ItemSubFeatureId { get; set; }

        public string ItemSubFeatureName { get; set; }

        public string Description { get; set; }

        public Sector Sector { get; set; }

    }
}
