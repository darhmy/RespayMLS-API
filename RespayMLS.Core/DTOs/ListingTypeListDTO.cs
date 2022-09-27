using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class ListingTypeListDTO
    {
        public int ListingTypeId { get; set; }

        public string Platforms { get; set; }

        public int SectorId { get; set; }

        public string Sector { get; set; }

        public int RoleId { get; set; }
        public string Role { get; set; }
    }
}
