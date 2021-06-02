using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidateAcademicsEducationBusiness : ICandidateAcademicsEducationBusiness
    {
        private readonly ICandidateAcademicEducationRepository _repository;

        public CandidateAcademicsEducationBusiness(ICandidateAcademicEducationRepository repository)
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

        public CandidateAcademicEducation Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidateAcademicEducation> GetByCandidate(int candidateID)
        {
            return _repository.GetByCandidate(candidateID);
        }

        public int Save(CandidateAcademicEducation candidateAcademicEducation)
        {
            return _repository.Save(candidateAcademicEducation);
        }
    }
}
