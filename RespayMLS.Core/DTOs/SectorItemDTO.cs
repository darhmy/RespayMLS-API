using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class SectorItemDTO
    {
        public int ItemTypeId { get; set; }
        public string ItemTypeName { get; set; }

        public int SectorId { get; set; }
        public string SectorName { get; set; }

        
    }
}
