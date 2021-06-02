using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CivilStateBusiness : ICivilStateBusiness
    {
        private readonly ICivilStateRepository _repository;

        public CivilStateBusiness(ICivilStateRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public CivilState Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CivilState> GetAll()
        {
            return _repository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public CivilState GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<CivilState> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(c => c.Name).ToList();
        }

        public int Save(CivilState civilState)
        {
            return _repository.Save(civilState);
        }
    }
}
