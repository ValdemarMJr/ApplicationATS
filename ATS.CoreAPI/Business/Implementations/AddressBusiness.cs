using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class AddressBusiness : IAddressBusiness
    {
        private readonly IAddressRepository _repository;

        public AddressBusiness(IAddressRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Address Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Address> GetAll()
        {
            return _repository.GetAll();
        }

        public int Save(Address address)
        {
            return _repository.Save(address);
        }
    }
}
