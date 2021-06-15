using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidateExperienceRepository : ICandidateExperienceRepository
    {
        private readonly SQLContext _context;

        public CandidateExperienceRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidateExperience = _context.CandidateExperiences.FirstOrDefault(ce => ce.ID == id);
            if (candidateExperience is null)
                throw new CandidateExperienceNotExistsExceptions();
            else
            {
                _context.CandidateExperiences.Remove(candidateExperience);
                return true;
            }
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            List<CandidateExperience> candidateExperiences = _context.CandidateExperiences.Where(ce => ce.CandidateID == candidateID).ToList();
            if (candidateExperiences is null || candidateExperiences.Count <= 0)
                throw new CandidateExperienceNotExistsExceptions();
            else
            {
                foreach (var item in candidateExperiences)
                {
                    _context.CandidateExperiences.Remove(item);
                }

                _context.SaveChanges();

                return true;
            }
        }

        public CandidateExperience Get(int id)
        {
            var candidateExperience = _context.CandidateExperiences.FirstOrDefault(ce => ce.ID == id);
            if (candidateExperience is null)
                throw new CandidateExperienceNotExistsExceptions();
            else
            {
                return candidateExperience;
            }
        }

        public List<CandidateExperience> GetByCandidate(int candidateID)
        {
            return _context.CandidateExperiences.Where(ce => ce.CandidateID == candidateID).ToList();
        }

        public int Save(CandidateExperience candidateExperiences)
        {
            int candidateExperieceID = 0;
            var candidateExperieceContext = _context.CandidateExperiences.FirstOrDefault(ce => ce.ID == candidateExperiences.ID);

            if (candidateExperiences.CandidateID == null || candidateExperiences.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateExperiences.CandidateID != null && candidateExperiences.CandidateID > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(c => c.ID == candidateExperiences.CandidateID);

                if (candidate == null || candidate.ID <= 0)
                    throw new CandidateIsInvalidExceptions();
            }
            else if (candidateExperiences.Activities == null || String.IsNullOrEmpty(candidateExperiences.Activities))
                throw new ActivitiesIsRequiredExceptions();
            else if (candidateExperiences.Company == null || String.IsNullOrEmpty(candidateExperiences.Company))
                throw new CompanyNameIsRequiredExceptions();
            else
            {
                if (candidateExperieceContext is null)
                {
                    _context.CandidateExperiences.Add(candidateExperiences);
                    _context.SaveChanges();

                    candidateExperieceID = candidateExperiences.ID;
                }
                else
                {
                    candidateExperieceContext.CandidateID = candidateExperiences.CandidateID;
                    candidateExperieceContext.Activities = candidateExperiences.Activities;
                    candidateExperieceContext.Company = candidateExperiences.Company;
                    candidateExperieceContext.DtAdmission = candidateExperiences.DtAdmission;
                    candidateExperieceContext.DtResignation = candidateExperiences.DtResignation;
                    _context.SaveChanges();

                    candidateExperieceID = candidateExperieceContext.ID;

                }
            }

            return candidateExperieceID;
        }
    }
    
}
