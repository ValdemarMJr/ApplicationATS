using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class ContactRepository : IContactRepository
    {
        private readonly SQLContext _context;

        public ContactRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.ID == id);
            if (contact is null)
                throw new ContactNotExistsException();
            else
            {
                _context.Contacts.Remove(contact);
                _context.SaveChanges();
                return true;
            }
        }

        public Contact Get(int id)
        {
            var contact = _context.Contacts.FirstOrDefault(c => c.ID == id);
            if (contact is null)
                throw new ContactNotExistsException();
            else
            {
                return contact;
            }
        }

        public List<Contact> GetAll()
        {
            return _context.Contacts.ToList();
        }

        public int Save(Contact contact)
        {
            int contactID = 0;
            var contactContext = _context.Contacts.FirstOrDefault(c => c.ID == contact.ID);

            if (contact.Name == null || String.IsNullOrEmpty(contact.Name))
                throw new ZipcodeIsRequiredException();
            else if (contact.Information == null || String.IsNullOrEmpty(contact.Information))
                throw new ContactInformationIsRequiredException();
            else if (contact.ContactTypeID == null || contact.ContactTypeID <= 0)
                throw new ContactTypeIsRequiredException();
            else if (contact.ContactTypeID != null || contact.ContactTypeID > 0)
            {
                ContactType contactType = _context.ContactTypes.FirstOrDefault(c => c.ID == contact.ContactTypeID);

                if (contactType == null || contactType.ID <= 0)
                    throw new ContactTypeIsInvalidException();
            }
            else
            {
                if (contactContext is null)
                {
                    _context.Contacts.Add(contact);
                    _context.SaveChanges();

                    contactID = contact.ID;
                }
                else
                {
                    contactContext.Name = contact.Name;
                    contactContext.Information = contact.Information;
                    contactContext.ContactTypeID = contact.ContactTypeID;
                    _context.SaveChanges();

                    contactID = contactContext.ID;

                }
            }

            return contactID;
        }
    }
}
