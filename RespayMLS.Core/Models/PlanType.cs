using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Models
{
    public class PlanType
    {
        public int PlanTypeId { get; set; }
        public string PlanTypeName { get; set; }

        public Module Module { get; set; }

    }
}
