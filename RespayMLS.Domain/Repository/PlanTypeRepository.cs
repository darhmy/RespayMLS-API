using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System.Collections.Generic;
using System.Linq;

namespace RespayMLS.Domain.Repository
{
    public class PlanTypeRepository : IPlanTypeRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public PlanTypeRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public PlanType AddPlanType(PlanType planType)
        {
            _respayMLSDbContext.PlanTypes.Add(planType);
            _respayMLSDbContext.SaveChanges();

            return planType;
        }

        public void Delete(int Id)
        {
            var getPlanType = _respayMLSDbContext.PlanTypes.Find(Id);

            _respayMLSDbContext.PlanTypes.Remove(getPlanType);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<PlanType> GetAllPlanTypes()
        {
            return _respayMLSDbContext.PlanTypes.ToList();
        }

        public PlanType GetPlanType(int Id)
        {
            var getPlanType = _respayMLSDbContext.PlanTypes.Find(Id);

            return getPlanType;
        }

        public PlanType UpdatePlanType(PlanType planType)
        {
            _respayMLSDbContext.Entry(planType).State = EntityState.Modified;
            _respayMLSDbContext.SaveChanges();

            return planType;
        }
    }
}
