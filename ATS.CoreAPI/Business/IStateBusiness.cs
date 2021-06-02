using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface IStateBusiness
    {
        State Get(int id);

        State GetByName(string name);

        State GetByShortName(string shortName);

        List<State> GetAll();

        List<State> GetOnlyActives();

        int Save(State state);

        bool Delete(int id);


    }
}
