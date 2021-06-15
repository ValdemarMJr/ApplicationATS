using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CandidateImprovmentCourseRepository : ICandidateImprovementCourseRepository
    {
        private readonly SQLContext _context;

        public CandidateImprovmentCourseRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var candidateImprovmentCourse = _context.CandidateImprovementCourses.FirstOrDefault(cic => cic.ID == id);
            if (candidateImprovmentCourse is null)
                throw new CandidateImprovmentCourseNotExistsExceptions();
            else
            {
                _context.CandidateImprovementCourses.Remove(candidateImprovmentCourse);
                _context.SaveChanges();
                return true;
            }
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            List<CandidateImprovementCourse> candidateImprovmentCourses = _context.CandidateImprovementCourses.Where(cic => cic.CandidateID == candidateID).ToList();
            if (candidateImprovmentCourses is null || candidateImprovmentCourses.Count <= 0)
                throw new CandidateExperienceNotExistsExceptions();
            else
            {
                foreach (var item in candidateImprovmentCourses)
                {
                    _context.CandidateImprovementCourses.Remove(item);
                }

                _context.SaveChanges();

                return true;
            }
        }

        public CandidateImprovementCourse Get(int id)
        {
            var candidateImprovmentCourse = _context.CandidateImprovementCourses.FirstOrDefault(cic => cic.ID == id);
            if (candidateImprovmentCourse is null)
                throw new CandidateExperienceNotExistsExceptions();
            else
            {
                return candidateImprovmentCourse;
            }
        }

        public List<CandidateImprovementCourse> GetByCandidate(int candidateID)
        {
            return _context.CandidateImprovementCourses.Where(cic => cic.CandidateID == candidateID).ToList();
        }

        public int Save(CandidateImprovementCourse candidateImprovementCourse)
        {
            int candidateImprovementCourseID = 0;
            var candidateImprovementCourseContext = _context.CandidateImprovementCourses.FirstOrDefault(ce => ce.ID == candidateImprovementCourse.ID);

            if (candidateImprovementCourse.CandidateID == null || candidateImprovementCourse.CandidateID <= 0)
                throw new CandidateIsRequiredExceptions();
            else if (candidateImprovementCourse.CandidateID != null && candidateImprovementCourse.CandidateID > 0)
            {
                Candidate candidate = _context.Candidates.FirstOrDefault(c => c.ID == candidateImprovementCourse.CandidateID);

                if (candidate == null || candidate.ID <= 0)
                    throw new CandidateIsInvalidExceptions();
            }
            else if (candidateImprovementCourse.ImprovementCourseID == null || candidateImprovementCourse.ImprovementCourseID <= 0)
                throw new ImprovmentCourseIsRequiredExceptions();
            else if (candidateImprovementCourse.ImprovementCourseID != null && candidateImprovementCourse.ImprovementCourseID > 0)
            {
                ImprovementCourse improvementCourse = _context.ImprovementCourses.FirstOrDefault(c => c.ID == candidateImprovementCourse.ImprovementCourseID);

                if (improvementCourse == null || improvementCourse.ID <= 0)
                    throw new ImprovmentCourseIsInvalidExceptions();
            }
            else if (candidateImprovementCourse.SituationCourseID == null || candidateImprovementCourse.SituationCourseID <= 0)
                throw new SituationCourseIsRequiredExceptions();
            else if (candidateImprovementCourse.SituationCourseID != null && candidateImprovementCourse.SituationCourseID > 0)
            {
                CourseSituation courseSituation = _context.CourseSituations.FirstOrDefault(c => c.ID == candidateImprovementCourse.SituationCourseID);

                if (courseSituation == null || courseSituation.ID <= 0)
                    throw new CourseSituationIsInvalidExceptions();
            }
            else
            {
                if (candidateImprovementCourseContext is null)
                {
                    _context.CandidateImprovementCourses.Add(candidateImprovementCourse);
                    _context.SaveChanges();

                    candidateImprovementCourseID = candidateImprovementCourse.ID;
                }
                else
                {
                    candidateImprovementCourseContext.CandidateID = candidateImprovementCourse.CandidateID;
                    candidateImprovementCourseContext.ImprovementCourseID = candidateImprovementCourse.ImprovementCourseID;
                    candidateImprovementCourseContext.SituationCourseID = candidateImprovementCourse.SituationCourseID;
                    candidateImprovementCourseContext.DtStart = candidateImprovementCourse.DtStart;
                    candidateImprovementCourseContext.DtFinish = candidateImprovementCourse.DtFinish;
                    _context.SaveChanges();

                    candidateImprovementCourseID = candidateImprovementCourseContext.ID;

                }
            }

            return candidateImprovementCourseID;
        }
    }
}
