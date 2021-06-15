using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly SQLContext _context;

        public ContactTypeRepository(SQLContext context)
        {
            _context = context;
        }

        public bool Delete(int id)
        {
            var contactType = _context.ContactTypes.FirstOrDefault(s => s.ID == id);
            if (contactType is null)
                throw new ContactTypesNotExistsException();
            else
            {
                _context.ContactTypes.Remove(contactType);
                _context.SaveChanges();
                return true;
            }
        }

        public ContactType Get(int id)
        {
            var contactType = _context.ContactTypes.FirstOrDefault(s => s.ID == id);
            if (contactType is null)
                throw new ContactTypesNotExistsException();
            else
            {
                return contactType;
            }
        }

        public List<ContactType> GetAll()
        {
            return _context.ContactTypes.ToList();
        }

        public ContactType GetByName(string name)
        {
            var contactType = _context.ContactTypes.FirstOrDefault(s => s.Name == name);
            if (contactType is null)
                throw new ContactTypesNotExistsException();
            else
            {
                return contactType;
            }
        }

        public List<ContactType> GetOnlyActives()
        {
            return _context.ContactTypes.Where(s => s.Inactive == false).ToList();
        }

        public int Save(ContactType contactType)
        {
            int contactTypeID = 0;
            var contactTypeContext = _context.ContactTypes.FirstOrDefault(s => s.Name == contactType.Name);

            if (contactType.Name == null || String.IsNullOrEmpty(contactType.Name))
                throw new NameRequiredException();
            else
            {
                if (contactTypeContext is null)
                {
                    _context.ContactTypes.Add(contactType);
                    _context.SaveChanges();

                    contactTypeID = contactType.ID;
                }
                else
                {
                    contactTypeContext.Name = contactType.Name;
                    contactTypeContext.Inactive = contactType.Inactive;

                    _context.SaveChanges();

                    contactTypeID = contactTypeContext.ID;
                }
            }

            return contactTypeID;
        }
    }
}
