using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class NeighborhoodBusiness : INeighborhoodBusiness
    {
        private readonly INeighborhoodRepository _repository;

        public NeighborhoodBusiness(INeighborhoodRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Neighborhood Get(int id)
        {
            return _repository.Get(id);
        }

        public List<Neighborhood> GetAll()
        {
            return _repository.GetAll().OrderBy(n => n.Name).ToList();
        }

        public List<Neighborhood> GetByCity(int cityID, bool onlyActives)
        {
            return _repository.GetByCity(cityID, onlyActives).OrderBy(n => n.Name).ToList();
        }

        public Neighborhood GetByName(int cityID, string name)
        {
            return _repository.GetByName(cityID, name);
        }

        public List<Neighborhood> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(n => n.Name).ToList();
        }

        public int Save(Neighborhood neighborhood)
        {
            return _repository.Save(neighborhood);
        }
    }
}
