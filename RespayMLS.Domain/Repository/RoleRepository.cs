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
    public class RoleRepository : IRoleRepository
    {
        private readonly RespayMLSDbContext _respayMLSDbContext;

        public RoleRepository(RespayMLSDbContext respayMLSDbContext)
        {
            _respayMLSDbContext = respayMLSDbContext;
        }
        public Role AddRole(Role role)
        {
            _respayMLSDbContext.Roles.Add(role);

            _respayMLSDbContext.SaveChanges();

            return role;
        }

        public void Delete(int Id)
        {
            var getRole = _respayMLSDbContext.Roles.Find(Id);

            _respayMLSDbContext.Roles.Remove(getRole);

            _respayMLSDbContext.SaveChanges();
        }

        public ICollection<Role> GetAllRoles()
        {
            return _respayMLSDbContext.Roles.ToList();
        }

        public async Task<ICollection<Role>> GetAllRoles(string navigation)
        {
            var getAllRoles = await _respayMLSDbContext.Roles.Include(navigation).ToListAsync();

            return getAllRoles;
        }

        public Role GetRole(int Id, string navigation)
        {
            var getRole = _respayMLSDbContext.Roles.Include(navigation).Where(x => x.RoleId == Id).FirstOrDefault();

            return getRole;
        }

        public Role GetRole(int Id)
        {
            var getRole = _respayMLSDbContext.Roles.Find(Id);

            return getRole;
        }

        public bool isRoleExist(string roleName)
        {
            var isExist = _respayMLSDbContext.Roles.Where(x => x.RoleName == roleName).Any();

            return isExist;
        }

        public Role UpdateRole(Role role)
        {
            _respayMLSDbContext.Entry(role).State = EntityState.Modified;
            _respayMLSDbContext.SaveChanges();

            return role;
        }
    }
}
