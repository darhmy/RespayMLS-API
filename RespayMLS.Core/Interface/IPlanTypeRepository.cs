using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IPlanTypeRepository
    {
        PlanType GetPlanType(int Id);

        ICollection<PlanType> GetAllPlanTypes();

        PlanType AddPlanType(PlanType planType);

        PlanType UpdatePlanType(PlanType planType);

        void Delete(int Id);
    }
}
