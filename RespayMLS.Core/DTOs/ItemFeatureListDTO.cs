using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class ItemFeatureListDTO
    {
        public int ItemFeatureId { get; set; }
        public string FeatureName { get; set; }

        public string Description { get; set; }

        public int SectorId { get; set; }
        public string Sector { get; set; }
    }
}
