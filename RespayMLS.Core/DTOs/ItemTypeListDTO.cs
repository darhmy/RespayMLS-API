using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class ItemTypeListDTO
    {
        public int ItemTypeId { get; set; }

        public string TypeName { get; set; }

        public int SectorId { get; set; }
        public string Sector { get; set; }
    }
}
