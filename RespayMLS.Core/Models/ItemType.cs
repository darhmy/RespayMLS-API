using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string TypeName { get; set; }

        public Sector Sector { get; set; }
    }
}
