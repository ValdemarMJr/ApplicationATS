using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class PersonalReferenceTypesBusiness : IPersonalReferenceTypesBusiness
    {
        private readonly IPersonalReferenceTypeRepository _repository;

        public PersonalReferenceTypesBusiness(IPersonalReferenceTypeRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public PersonalReferenceType Get(int id)
        {
            return _repository.Get(id);
        }

        public List<PersonalReferenceType> GetAll()
        {
            return _repository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public PersonalReferenceType GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<PersonalReferenceType> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(c => c.Name).ToList();
        }

        public int Save(PersonalReferenceType contactType)
        {
            return _repository.Save(contactType);
        }
    }
}
