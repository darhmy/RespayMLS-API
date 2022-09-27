using RespayMLS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RespayMLS.Core.Interface
{
    public interface IRoleRepository
    {
        Role GetRole(int Id);

        Role GetRole(int Id, string navigation);

        ICollection<Role> GetAllRoles();

        Task<ICollection<Role>> GetAllRoles(string navigation);

        Role AddRole(Role role);

        Role UpdateRole(Role role);

        void Delete(int Id);

        bool isRoleExist(string roleName);
    }
}
