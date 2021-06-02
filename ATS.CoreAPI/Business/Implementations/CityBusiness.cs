using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CityBusiness : ICityBusiness
    {
        private readonly ICityRepository _repository;

        public CityBusiness(ICityRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public City Get(int id)
        {
            return _repository.Get(id);
        }

        public List<City> GetAll()
        {
            return _repository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public City GetByName(int stateID, string name)
        {
            return _repository.GetByName(stateID, name);
        }

        public List<City> GetByState(int stateID, bool onlyActives)
        {
            return _repository.GetByState(stateID, onlyActives).OrderBy(c => c.Name).ToList();
        }

        public List<City> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(c => c.Name).ToList();
        }

        public int Save(City city)
        {
            return _repository.Save(city);
        }
    }
}
