using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidateAcademicEducationRepository : ICandidateAcademicEducationRepository
    {
        private readonly SQLContext _context;

        public CandidateAcademicEducationRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidateAcademicEducation = _context.CandidateAcademicsEducation.FirstOrDefault(cae => cae.ID == id);
            if (candidateAcademicEducation is null)
                throw new CandidateAcademicsEducationsNotExistsExceptions();
            else
            {
                _context.CandidateAcademicsEducation.Remove(candidateAcademicEducation);
                return true;
            }
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            List<CandidateAcademicEducation>  candidateAcademicsEducation = _context.CandidateAcademicsEducation.Where(cae => cae.CandidateID == candidateID).ToList();
            if (candidateAcademicsEducation is null  || candidateAcademicsEducation.Count <= 0)
                throw new CandidateAcademicsEducationsNotExistsExceptions();
            else
            {
                foreach (var item in candidateAcademicsEducation)
                {
                    _context.CandidateAcademicsEducation.Remove(item);
                    _context.SaveChanges();
                }
               
                return true;
            }
        }

        public CandidateAcademicEducation Get(int id)
        {
            var candidateAcademicEducation = _context.CandidateAcademicsEducation.FirstOrDefault(cae => cae.ID == id);
            if (candidateAcademicEducation is null)
                throw new CandidateAcademicsEducationsNotExistsExceptions();
            else
            {
                return candidateAcademicEducation;
            }
        }

        public List<CandidateAcademicEducation> GetByCandidate(int candidateID)
        {
            return _context.CandidateAcademicsEducation.Where(cae => cae.CandidateID == candidateID).ToList();
        }

        public int Save(CandidateAcademicEducation candidateAcademicEducation)
        {
            int candidateAcademicEducationID = 0;
            var candidateAcademicEducationContext = _context.CandidateAcademicsEducation.FirstOrDefault(cae => cae.ID == candidateAcademicEducation.ID);

            if (candidateAcademicEducation.CandidateID == null || candidateAcademicEducation.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateAcademicEducation.CandidateID != null && candidateAcademicEducation.CandidateID > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(c => c.ID == candidateAcademicEducation.CandidateID);

                if(candidate == null || candidate.ID <= 0)
                    throw new CandidateIsInvalidExceptions();
            }
            else if (candidateAcademicEducation.AcademicEducationID == null || candidateAcademicEducation.AcademicEducationID <= 0)
                throw new AcademicEducationIsRequiredExceptions();
            else if (candidateAcademicEducation.AcademicEducationID != null && candidateAcademicEducation.AcademicEducationID > 0)
            {
                AcademicEducation academicEducation = _context.AcademicsEducation.FirstOrDefault(a => a.ID == candidateAcademicEducation.AcademicEducationID);

                if (academicEducation == null || academicEducation.ID <= 0)
                    throw new AcademicEducationIsInvalidExceptions();
            }
            else if (candidateAcademicEducation.SituationCourseID == null || candidateAcademicEducation.SituationCourseID <= 0)
                throw new CourseSituationIsRequiredExceptions();
            else if (candidateAcademicEducation.SituationCourseID != null && candidateAcademicEducation.SituationCourseID > 0)
            {
                CourseSituation courseSituation = _context.CourseSituations.FirstOrDefault(c => c.ID == candidateAcademicEducation.SituationCourseID);

                if (courseSituation == null || courseSituation.ID <= 0)
                    throw new CourseSituationIsInvalidExceptions();
            }
            else
            {
                if (candidateAcademicEducationContext is null)
                {
                     _context.CandidateAcademicsEducation.Add(candidateAcademicEducation);
                    _context.SaveChanges();

                    candidateAcademicEducationID = candidateAcademicEducation.ID;
                }
                else
                {
                    candidateAcademicEducationContext.CandidateID = candidateAcademicEducation.CandidateID;
                    candidateAcademicEducationContext.AcademicEducationID = candidateAcademicEducation.AcademicEducationID;
                    candidateAcademicEducationContext.SituationCourseID = candidateAcademicEducation.SituationCourseID;
                    candidateAcademicEducationContext.DtStart = candidateAcademicEducation.DtStart;
                    candidateAcademicEducationContext.DtFinish = candidateAcademicEducation.DtFinish;
                    _context.SaveChanges();

                    candidateAcademicEducationID = candidateAcademicEducationContext.ID;

                }
            }

            return candidateAcademicEducationID;
        }
    }
}
