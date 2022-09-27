using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class Sector
    {
        public int SectorId { get; set; }
        public string SectorName { get; set; }

        public ICollection<Role> Roles { get; set; }

        public ICollection<ListingType> ListingTypes { get; set; }

        public ICollection<ItemType> ItemTypes { get; set; }

        public ICollection<ItemFeature> ItemFeatures { get; set; }

        public ICollection<ItemSubFeature> ItemSubFeatures { get; set; }
    }
}

