using System.Collections.Generic;

namespace RespayMLS.Core.Models
{
    public class Module
    {
        public int ModuleId { get; set; }
        public string ModuleName { get; set; }

        public ICollection<PlanType> PlanTypes { get; set; }
    }
}
