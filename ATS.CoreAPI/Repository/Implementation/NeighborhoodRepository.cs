using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class NeighborhoodRepository : INeighborhoodRepository
    {
        private readonly SQLContext _context;

        public NeighborhoodRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var neighborhoodContext = _context.Neighborhoods.FirstOrDefault(s => s.ID == id);
            if (neighborhoodContext is null)
                throw new NeighborhoodsNotExistsException();
            else
            {
                _context.Neighborhoods.Remove(neighborhoodContext);
                _context.SaveChanges();
                return true;
            }
        }

        public Neighborhood Get(int id)
        {
            return _context.Neighborhoods.FirstOrDefault(c => c.ID == id);
        }

        public List<Neighborhood> GetAll()
        {
            return _context.Neighborhoods.ToList();
        }

        public List<Neighborhood> GetByCity(int cityID, bool onlyActives)
        {
            return _context.Neighborhoods.Where(n=> n.CityID.Equals(cityID) && (!onlyActives || (onlyActives && n.Inactive == false))).ToList();
        }

        public Neighborhood GetByName(int cityID, string name)
        {
            return _context.Neighborhoods.FirstOrDefault(n => n.CityID.Equals(cityID) && n.Name.Equals(name));
        }
    

        public List<Neighborhood> GetOnlyActives()
        {
            return _context.Neighborhoods.Where(n => n.Inactive == false).ToList();
        }

        public int Save(Neighborhood neighborhood)
        {
            int neighborhoodID = 0;
            var neighborhoodContext = _context.Neighborhoods.FirstOrDefault(n => n.Name == neighborhood.Name && n.CityID == neighborhood.CityID);

            if (neighborhood.Name == null || String.IsNullOrEmpty(neighborhood.Name))
                throw new NameRequiredException();
            else if (neighborhood.CityID == null || neighborhood.CityID <= 0)
                throw new CityOfNeighborhoodIsRequired();
            else
            {
                if (neighborhoodContext is null)
                {
                    _context.Neighborhoods.Add(neighborhood);
                    _context.SaveChanges();

                    neighborhoodID = neighborhood.ID;
                }
                else
                {
                    neighborhoodContext.Name = neighborhood.Name;
                    neighborhoodContext.CityID = neighborhood.CityID;
                    neighborhoodContext.Inactive = neighborhood.Inactive;

                    _context.SaveChanges();

                    neighborhoodID = neighborhoodContext.ID;
                }
            }

            return neighborhoodID;
        }
    }
}
