using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class GenderBusiness : IGenderBusiness
    {
        private readonly IGenderRepository _repository;

        public GenderBusiness(IGenderRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Gender Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Gender> GetAll()
        {
            return _repository.GetAll().OrderBy(g => g.Name).ToList();
        }

        public Gender GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<Gender> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(g => g.Name).ToList();
        }

        public int Save(Gender gender)
        {
            return _repository.Save(gender);
        }
    }
}
