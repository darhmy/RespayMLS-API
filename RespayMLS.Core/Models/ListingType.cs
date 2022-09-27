using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class ListingType
    {
        public int ListingTypeId { get; set; }
        public string Platforms { get; set; }

        public Sector Sector { get; set; }

        public Role Role { get; set; }
    }
}
