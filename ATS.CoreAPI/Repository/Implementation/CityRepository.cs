using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CityRepository : ICityRepository
    {
        private readonly SQLContext _context;

        public CityRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var cityContext = _context.Cities.FirstOrDefault(s => s.ID == id);
            if (cityContext is null)
                throw new CitiesNotExistsException();
            else
            {
                _context.Cities.Remove(cityContext);
                _context.SaveChanges();
                return true;
            }
        }

        public City Get(int id)
        {
            return _context.Cities.FirstOrDefault(c => c.ID == id);
        }

        public List<City> GetAll()
        {
            return _context.Cities.ToList();
        }

        public City GetByName(int stateID, string name)
        {
            return _context.Cities.FirstOrDefault(c => c.StateID.Equals(stateID) && c.Name.Equals(name));
        }

        public List<City> GetByState(int stateID, bool onlyActives)
        {
            return _context.Cities.Where(c => c.StateID.Equals(stateID) &&  (!onlyActives || ( onlyActives &&  c.Inactive == false))).ToList();
        }

        public List<City> GetOnlyActives()
        {
            return _context.Cities.Where(c => c.Inactive == false).ToList();
        }

        public int Save(City city)
        {
            int cityID = 0;
            var cityContext = _context.Cities.FirstOrDefault(s => s.Name == city.Name && s.StateID == city.StateID);

            if (city.Name == null || String.IsNullOrEmpty(city.Name))
                throw new NameRequiredException();
            else if (city.StateID == null || city.StateID <= 0)
                throw new StateOfCityIsRequired();
            else
            {
                if (cityContext is null)
                {
                    _context.Cities.Add(city);
                    _context.SaveChanges();

                    cityID = city.ID;
                }
                else
                {
                    cityContext.Name = city.Name;
                    cityContext.StateID = city.StateID;
                    cityContext.Inactive = city.Inactive;

                    _context.SaveChanges();

                    cityID = cityContext.ID;
                }
            }

            return cityID;
        }
    }
}
