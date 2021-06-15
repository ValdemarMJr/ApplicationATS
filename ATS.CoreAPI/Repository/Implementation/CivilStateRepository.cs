using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CivilStateRepository : ICivilStateRepository
    {

        private readonly SQLContext _context;

        public CivilStateRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var civilState = _context.CivilStates.FirstOrDefault(s => s.ID == id);
            if (civilState is null)
                throw new CivilStatesNotExistsException();
            else
            {
                _context.CivilStates.Remove(civilState);
                _context.SaveChanges();
                return true;
            }
        }

        public CivilState Get(int id)
        {
            var civilState = _context.CivilStates.FirstOrDefault(s => s.ID == id);
            if (civilState is null)
                throw new CivilStatesNotExistsException();
            else
            {
                return civilState;
            }
        }

        public List<CivilState> GetAll()
        {
            return _context.CivilStates.ToList();
        }

        public CivilState GetByName(string name)
        {
            var civilState = _context.CivilStates.FirstOrDefault(s => s.Name == name);
            if (civilState is null)
                throw new CivilStatesNotExistsException();
            else
            {
                return civilState;
            }
        }

        public List<CivilState> GetOnlyActives()
        {
            return _context.CivilStates.Where(s => s.Inactive == false).ToList();
        }

        public int Save(CivilState civilState)
        {
            int stateID = 0;
            var civilStateContext = _context.CivilStates.FirstOrDefault(s => s.Name == civilState.Name);

            if (civilState.Name == null || String.IsNullOrEmpty(civilState.Name))
                throw new NameRequiredException();
            else
            {
                if (civilStateContext is null)
                {
                    _context.CivilStates.Add(civilState);
                    _context.SaveChanges();

                    stateID = civilState.ID;
                }
                else
                {
                    civilStateContext.Name = civilState.Name;
                    civilStateContext.Inactive = civilState.Inactive;

                    _context.SaveChanges();

                    stateID = civilStateContext.ID;

                }
            }

            return stateID;
        }
    }
}
