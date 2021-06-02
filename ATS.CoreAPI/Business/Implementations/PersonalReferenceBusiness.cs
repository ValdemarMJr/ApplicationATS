using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class PersonalReferenceBusiness : IPersonalReferenceBusiness
    {
        private readonly IPersonalReferenceRepository _repository;

        public PersonalReferenceBusiness(IPersonalReferenceRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public PersonalReference Get(int id)
        {
            return _repository.Get(id);
        }

        public List<PersonalReference> GetAll()
        {
            return _repository.GetAll();
        }

        public int Save(PersonalReference personalReference)
        {
            return _repository.Save(personalReference);
        }
    }
}
