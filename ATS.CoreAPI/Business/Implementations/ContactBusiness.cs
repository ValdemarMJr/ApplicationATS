using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class ContactBusiness : IContactBusiness
    {
        private readonly IContactRepository _repository;

        public ContactBusiness(IContactRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Contact Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Contact> GetAll()
        {
            return _repository.GetAll();
        }

        public int Save(Contact contact)
        {
            return _repository.Save(contact);
        }
    }
}
