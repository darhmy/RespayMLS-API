using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class ItemFeature
    {
        public int ItemFeatureId { get; set; }

        public string FeatureName { get; set; }

        public string Description { get; set; }

        public Sector Sector { get; set; }
    }
}
