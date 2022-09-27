using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNumber { get; set; }

        public Sector Sector { get; set; }

        public ICollection<ListingType> ListingTypes { get; set; }

    }
}
