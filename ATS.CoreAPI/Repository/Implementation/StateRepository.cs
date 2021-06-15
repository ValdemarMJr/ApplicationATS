using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public class StateRepository : IStateRepository
    {
        private readonly SQLContext _context;

        public StateRepository(SQLContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var stateContext = _context.States.FirstOrDefault(s => s.ID == id);
            if (stateContext is null)
                throw new StateNotExistsException();
            else
            {
                _context.States.Remove(stateContext);
                _context.SaveChanges();
                return true;
            }
        }

        public State Get(int id)
        {
            var stateContext = _context.States.FirstOrDefault(s => s.ID == id);
            if (stateContext is null)
                throw new StateNotExistsException();
            else
            {
                return stateContext;
            }
        }

        public List<State> GetAll()
        {
            return _context.States.ToList();
        }

        public State GetByName(string name)
        {
            var stateContext = _context.States.FirstOrDefault(s => s.Name == name);
            if (stateContext is null)
                throw new StateNotExistsException();
            else
            {
                return stateContext;
            }
        }

        public State GetByShortName(string shortName)
        {
            var stateContext = _context.States.FirstOrDefault(s => s.ShortName == shortName);
            if (stateContext is null)
                throw new StateNotExistsException();
            else
            {
                return stateContext;
            }
        }

        public List<State> GetOnlyActives()
        {
            return _context.States.Where(s => s.Inactive == false).ToList();
        }

        public int Save(State state)
        {
            int stateID = 0;
            var stateContext = _context.States.FirstOrDefault(s => s.Name == state.Name);

            if (state.Name == null || String.IsNullOrEmpty(state.Name))
                throw new NameRequiredException();
            else if (state.ShortName == null || String.IsNullOrEmpty(state.ShortName))
                throw new ShortNameIsRequired();            
            else
            {
                if (stateContext is null)
                {
                    _context.States.Add(state);
                    _context.SaveChanges();

                    stateID = state.ID;
                }
                else
                {
                    stateContext.Name = state.Name;
                    stateContext.ShortName = state.ShortName;
                    stateContext.Inactive = state.Inactive;

                    _context.SaveChanges();

                    stateID = stateContext.ID;

                }
            }

            return stateID;
        }
    }
}
