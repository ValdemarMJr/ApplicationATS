using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly SQLContext _context;

        public RoleRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.ID == id);
            if (role is null)
                throw new RolesNotExistsException();
            else
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
                return true;
            }
        }

        public Role Get(int id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.ID == id);
            if (role is null)
                throw new RolesNotExistsException();
            else
            {
                return role;
            }
        }

        public List<Role> GetAll()
        {
            return _context.Roles.Where(r=> r.Inactive == false).ToList();
        }

        public Role GetByName(string name)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Name == name);
            if (role is null)
                throw new RolesNotExistsException();
            else
            {
                return role;
            }
        }

        public List<Role> GetOnlyActives()
        {
            return _context.Roles.Where(r => r.Inactive == false).ToList();
        }

        public int Save(Role role)
        {
            int roleID = 0;
            var roleContext = _context.Roles.FirstOrDefault(r => r.Name == role.Name);

            if (role.Name == null || String.IsNullOrEmpty(role.Name))
                throw new NameRequiredException();
            else
            {
                if (roleContext is null)
                {
                    _context.Roles.Add(role);
                    _context.SaveChanges();

                    roleID = role.ID;
                }
                else
                {
                    roleContext.Name = role.Name;
                    roleContext.Inactive = role.Inactive;

                    _context.SaveChanges();

                    roleID = roleContext.ID;

                }
            }

            return roleID;
        }
    }
}
