using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface ICityBusiness
    {
        City Get(int id);

        City GetByName(int stateID, string name);

        List<City> GetAll();

        List<City> GetByState(int stateID, bool onlyActives);

        List<City> GetOnlyActives();

        int Save(City city);

        bool Delete(int id);
    }
}
