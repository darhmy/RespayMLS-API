using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.DTOs
{
    public class RoleSectorDTO
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNumber { get; set; }
        public int SectorId { get; set; }
        public string SectorName { get; set; }
    }
}
