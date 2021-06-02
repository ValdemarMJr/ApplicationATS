using ATS.CoreAPI.Business;
using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Bussiness.Implementations
{
    public class StateBusiness : IStateBusiness
    {
        private readonly IStateRepository _repository;

        public StateBusiness(IStateRepository repository)
        {
            _repository = repository;
        }

        State IStateBusiness.GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        State IStateBusiness.GetByShortName(string shortName)
        {
            return _repository.GetByShortName(shortName);
        }

        List<State> IStateBusiness.GetAll()
        {
            return _repository.GetAll().OrderBy(s => s.Name).ToList();
        }

        List<State> IStateBusiness.GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(s => s.Name).ToList();
        }

        int IStateBusiness.Save(State state)
        {
            return _repository.Save(state);
        }

        bool IStateBusiness.Delete(int id)
        {
            return _repository.Delete(id);
        }

        public State Get(int id)
        {
            return _repository.Get(id);
        }
    }
}
