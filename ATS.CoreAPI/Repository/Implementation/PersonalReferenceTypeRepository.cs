using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public class PersonalReferenceTypeRepository : IPersonalReferenceTypeRepository
    {
        private readonly SQLContext _context;

        public PersonalReferenceTypeRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var personalReferenceType = _context.PersonalReferenceTypes.FirstOrDefault(p => p.ID == id);
            if (personalReferenceType is null)
                throw new PersonalReferenceTypeNotExistsException();
            else
            {
                _context.PersonalReferenceTypes.Remove(personalReferenceType);
                _context.SaveChanges();
                return true;
            }
        }

        public PersonalReferenceType Get(int id)
        {
            var personalReferenceType = _context.PersonalReferenceTypes.FirstOrDefault(s => s.ID == id);
            if (personalReferenceType is null)
                throw new ContactTypesNotExistsException();
            else
            {
                return personalReferenceType;
            }
        }

        public List<PersonalReferenceType> GetAll()
        {
            return _context.PersonalReferenceTypes.ToList();
        }

        public PersonalReferenceType GetByName(string name)
        {
            var personalReferenceType = _context.PersonalReferenceTypes.FirstOrDefault(s => s.Name == name);
            if (personalReferenceType is null)
                throw new ContactTypesNotExistsException();
            else
            {
                return personalReferenceType;
            }
        }

        public List<PersonalReferenceType> GetOnlyActives()
        {
            return _context.PersonalReferenceTypes.Where(s => s.Inactive == false).ToList();
        }

        public int Save(PersonalReferenceType personalReferenceType)
        {
            int personalReferenceTypeID = 0;
            var personalReferenceTypeContext = _context.PersonalReferenceTypes.FirstOrDefault(s => s.Name == personalReferenceType.Name);

            if (personalReferenceType.Name == null || String.IsNullOrEmpty(personalReferenceType.Name))
                throw new NameRequiredException();
            else
            {
                if (personalReferenceTypeContext is null)
                {
                    _context.PersonalReferenceTypes.Add(personalReferenceType);
                    _context.SaveChanges();

                    personalReferenceTypeID = personalReferenceType.ID;
                }
                else
                {
                    personalReferenceTypeContext.Name = personalReferenceType.Name;
                    personalReferenceTypeContext.Inactive = personalReferenceType.Inactive;

                    _context.SaveChanges();

                    personalReferenceTypeID = personalReferenceTypeContext.ID;
                }
            }

            return personalReferenceTypeID;
        }
    }
}
