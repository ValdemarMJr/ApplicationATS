using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidateContactRepository : ICandidateContactRepository
    {
        private readonly SQLContext _context;

        public CandidateContactRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidateContact = _context.CandidateContacts.FirstOrDefault(cc => cc.ID == id);
            if (candidateContact is null)
                throw new CandidateContactNotExistsExceptions();
            else
            {
                _context.CandidateContacts.Remove(candidateContact);
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            List<CandidateContact> candidateContacts = _context.CandidateContacts.Where(cc => cc.CandidateID == candidateID).ToList();
            if (candidateContacts is null || candidateContacts.Count <= 0)
                throw new CandidateContactNotExistsExceptions();
            else
            {
                foreach (var item in candidateContacts)
                {
                    _context.CandidateContacts.Remove(item);
                }

                _context.SaveChanges();

                return true;
            }
        }

        public CandidateContact Get(int id)
        {
            var candidateContact = _context.CandidateContacts.FirstOrDefault(cc => cc.ID == id);
            if (candidateContact is null)
                throw new CandidateContactNotExistsExceptions();
            else
            {
                return candidateContact;
            }
        }

        public List<CandidateContact> GetByCandidate(int candidateID)
        {
            return _context.CandidateContacts.Where(cc => cc.CandidateID == candidateID).ToList();
        }

        public int Save(CandidateContact candidateContact)
        {
            int candidateContactID = 0;
            var candidateContactContext = _context.CandidateContacts.FirstOrDefault(cc => cc.ID == candidateContact.ID);

            if (candidateContact.CandidateID == null || candidateContact.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateContact.CandidateID != null && candidateContact.CandidateID > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(c => c.ID == candidateContact.CandidateID);

                if (candidate == null || candidate.ID <= 0)
                    throw new CandidateIsInvalidExceptions();
            }
            else if (candidateContact.ContactID == null || candidateContact.ContactID <= 0)
                throw new ContactIsRequiredExceptions();
            else if (candidateContact.ContactID != null && candidateContact.ContactID > 0)
            {
                Contact contact = _context.Contacts.FirstOrDefault(c => c.ID == candidateContact.ContactID);

                if (contact == null || contact.ID <= 0)
                    throw new ContactIsInvalidExceptions();
            }
            else
            {
                if (candidateContactContext is null)
                {
                    _context.CandidateContacts.Add(candidateContact);
                    _context.SaveChanges();

                    candidateContactID = candidateContact.ID;
                }
                else
                {
                    candidateContactContext.CandidateID = candidateContact.CandidateID;
                    candidateContactContext.ContactID = candidateContact.ContactID;

                    _context.SaveChanges();

                    candidateContactID = candidateContactContext.ID;

                }
            }

            return candidateContactID;
        }
    }
}
