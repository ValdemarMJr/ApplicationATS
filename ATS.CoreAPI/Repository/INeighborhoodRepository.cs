using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface INeighborhoodRepository
    {
        Neighborhood Get(int id);

        Neighborhood GetByName(int cityID, string name);

        List<Neighborhood> GetAll();

        List<Neighborhood> GetByCity(int cityID, bool onlyActives);

        List<Neighborhood> GetOnlyActives();

        int Save(Neighborhood neighborhood);

        bool Delete(int id); 
    }
}
