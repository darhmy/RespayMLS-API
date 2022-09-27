using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IModuleRepository
    {
        Module GetModule(int Id);

        ICollection<Module> GetAllModules();

        Module AddModule(Module module);

        Module UpdateModule(Module module);

        void Delete(int Id);
    }
}
