using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class RoleBusiness : IRoleBusiness
    {
        private readonly IRoleRepository _repository;

        public RoleBusiness(IRoleRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Role Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Role> GetAll()
        {
            return _repository.GetAll().OrderBy(r => r.Name).ToList();
        }

        public Role GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<Role> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(r => r.Name).ToList();
        }

        public int Save(Role role)
        {
            return _repository.Save(role);
        }
    }
}
