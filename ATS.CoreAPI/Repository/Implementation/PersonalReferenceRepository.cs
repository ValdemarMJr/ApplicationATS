using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class PersonalReferenceRepository : IPersonalReferenceRepository
    {
        private readonly SQLContext _context;

        public PersonalReferenceRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var personalReferences = _context.PersonalReferences.FirstOrDefault(p => p.ID == id);
            if (personalReferences is null)
                throw new PersonalReferenceNotExistsException();
            else
            {
                _context.PersonalReferences.Remove(personalReferences);
                _context.SaveChanges();
                return true;
            }
        }

        public PersonalReference Get(int id)
        {
            var personalReferences = _context.PersonalReferences.FirstOrDefault(p => p.ID == id);
            if (personalReferences is null)
                throw new PersonalReferenceNotExistsException();
            else
            {
                return personalReferences;
            }
        }

        public List<PersonalReference> GetAll()
        {
            return _context.PersonalReferences.ToList();
        }

        public int Save(PersonalReference personalReference)
        {
            int personalReferenceID = 0;
            var personalReferenceContext = _context.PersonalReferences.FirstOrDefault(p => p.ID == personalReference.ID);

            if (personalReference.Name == null || String.IsNullOrEmpty(personalReference.Name))
                throw new PersonalReferenceNameIsRequiredException();
            else if (personalReference.Telephone == null || String.IsNullOrEmpty(personalReference.Telephone))
                throw new PersonalReferenceTelehoneIsRequiredException();
            else if (personalReference.PersonalReferenceTypeID == null || personalReference.PersonalReferenceTypeID <= 0)
                throw new PersonalReferenceTypeIsRequiredException();
            else if (personalReference.PersonalReferenceTypeID != null || personalReference.PersonalReferenceTypeID > 0)
            {
                PersonalReferenceType personalReferenceType = _context.PersonalReferenceTypes.FirstOrDefault(prt => prt.ID == personalReference.PersonalReferenceTypeID);

                if (personalReferenceType == null || personalReferenceType.ID <= 0)
                    throw new PersonalReferenceTypeIsInvalidException();
            }
            else
            {
                if (personalReferenceContext is null)
                {
                    _context.PersonalReferences.Add(personalReference);
                    _context.SaveChanges();
                    personalReferenceID = personalReference.ID;
                }
                else
                {
                    personalReferenceContext.Name = personalReference.Name;
                    personalReferenceContext.Telephone = personalReference.Telephone;
                    personalReferenceContext.PersonalReferenceTypeID = personalReference.PersonalReferenceTypeID;

                    _context.SaveChanges();

                    personalReferenceID = personalReferenceContext.ID;

                }
            }

            return personalReferenceID;
        }
    }
}
