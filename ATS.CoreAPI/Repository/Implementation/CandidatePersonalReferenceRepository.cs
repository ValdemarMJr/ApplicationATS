using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidatePersonalReferenceRepository : ICandidatePersonalReferenceRepository
    {
        private readonly SQLContext _context;

        public CandidatePersonalReferenceRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidatePersonalReference = _context.CandidatePersonalReferences.FirstOrDefault(cpr => cpr.ID == id);
            if (candidatePersonalReference is null)
                throw new CandidatePersonalReferenceNotExistsExceptions();
            else
            {
                _context.CandidatePersonalReferences.Remove(candidatePersonalReference);
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            List<CandidatePersonalReference> candidatePersonalReferences = _context.CandidatePersonalReferences.Where(cpr => cpr.CandidateID == candidateID).ToList();
            if (candidatePersonalReferences is null || candidatePersonalReferences.Count <= 0)
                throw new CandidatePersonalReferenceNotExistsExceptions();
            else
            {
                foreach (var item in candidatePersonalReferences)
                {
                    _context.CandidatePersonalReferences.Remove(item);
                }

                _context.SaveChanges();

                return true;
            }
        }

        public CandidatePersonalReference Get(int id)
        {
            var candidatePersonalReference = _context.CandidatePersonalReferences.FirstOrDefault(cpr => cpr.ID == id);
            if (candidatePersonalReference is null)
                throw new CandidatePersonalReferenceNotExistsExceptions();
            else
            {
                return candidatePersonalReference;
            }
        }

        public List<CandidatePersonalReference> GetByCandidate(int candidateID)
        {
            return _context.CandidatePersonalReferences.Where(cpr => cpr.CandidateID == candidateID).ToList();
        }

        public int Save(CandidatePersonalReference candidatePersonalReference)
        {
            int candidatePersonalReferenceID = 0;
            var candidatePersonalReferenceContext = _context.CandidatePersonalReferences.FirstOrDefault(cc => cc.ID == candidatePersonalReference.ID);

            if (candidatePersonalReference.CandidateID == null || candidatePersonalReference.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidatePersonalReference.CandidateID != null && candidatePersonalReference.CandidateID > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(c => c.ID == candidatePersonalReference.CandidateID);

                if (candidate == null || candidate.ID <= 0)
                    throw new CandidateIsInvalidExceptions();
            }
            else if (candidatePersonalReference.PersonalReferenceID == null || candidatePersonalReference.PersonalReferenceID <= 0)
                throw new PersonalReferenceIsRequiredExceptions();
            else if (candidatePersonalReference.PersonalReferenceID != null && candidatePersonalReference.PersonalReferenceID > 0)
            {
                PersonalReference personalReference = _context.PersonalReferences.FirstOrDefault(pr => pr.ID == candidatePersonalReference.PersonalReferenceID);

                if (personalReference == null || personalReference.ID <= 0)
                    throw new PersonalReferenceIsInvalidExceptions();
            }
            else
            {
                if (candidatePersonalReferenceContext is null)
                {
                    _context.CandidatePersonalReferences.Add(candidatePersonalReference);
                    _context.SaveChanges();

                    candidatePersonalReferenceID = candidatePersonalReference.ID;
                }
                else
                {
                    candidatePersonalReferenceContext.CandidateID = candidatePersonalReference.CandidateID;
                    candidatePersonalReferenceContext.PersonalReferenceID = candidatePersonalReference.PersonalReferenceID;

                    _context.SaveChanges();

                    candidatePersonalReferenceID = candidatePersonalReferenceContext.ID;

                }
            }

            return candidatePersonalReferenceID;
        }
    }
}
