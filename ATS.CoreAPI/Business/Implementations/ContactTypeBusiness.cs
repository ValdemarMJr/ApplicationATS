using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class ContactTypeBusiness : IContactTypeBusiness
    {
        private readonly IContactTypeRepository _repository;

        public ContactTypeBusiness(IContactTypeRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public ContactType Get(int id)
        {
            return _repository.Get(id);
        }

        public List<ContactType> GetAll()
        {
            return _repository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public ContactType GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<ContactType> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(c => c.Name).ToList();
        }

        public int Save(ContactType contactType)
        {
            return _repository.Save(contactType);
        }
    }
}
