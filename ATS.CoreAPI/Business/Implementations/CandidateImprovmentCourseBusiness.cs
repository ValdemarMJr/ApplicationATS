using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidateImprovmentCourseBusiness : ICandidateImprovmentCourseBusiness
    {
        private readonly ICandidateImprovementCourseRepository _repository;

        public CandidateImprovmentCourseBusiness(ICandidateImprovementCourseRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public bool DeleteByCandidateID(int candidateID)
        {
            return _repository.DeleteByCandidateID(candidateID);
        }

        public CandidateImprovementCourse Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidateImprovementCourse> GetByCandidate(int candidateID)
        {
            return _repository.GetByCandidate(candidateID);
        }

        public int Save(CandidateImprovementCourse candidateImprovementCourse)
        {
            return _repository.Save(candidateImprovementCourse);
        }
    }
}
