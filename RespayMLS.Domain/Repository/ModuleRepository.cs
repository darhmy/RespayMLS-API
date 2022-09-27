using Microsoft.EntityFrameworkCore;
using RespayMLS.Core.Interface;
using RespayMLS.Core.Models;
using RespayMLS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Domain.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public ModuleRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public Module AddModule(Module module)
        {
            _respayMLSDbContext.Modules.Add(module);

            _respayMLSDbContext.SaveChanges();

            return module;
        }

        public void Delete(int Id)
        {
            var getModule = _respayMLSDbContext.Modules.Find(Id);

            _respayMLSDbContext.Modules.Remove(getModule);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<Module> GetAllModules()
        {
            return _respayMLSDbContext.Modules.ToList();
        }

        public Module GetModule(int Id)
        {
            var getModule = _respayMLSDbContext.Modules.Find(Id);

            return getModule;
        }

        public Module UpdateModule(Module module)
        {
            _respayMLSDbContext.Entry(module).State = EntityState.Modified;

            _respayMLSDbContext.SaveChanges();

            return module;
        }
    }
}
