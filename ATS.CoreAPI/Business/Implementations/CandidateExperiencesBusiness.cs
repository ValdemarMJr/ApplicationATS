using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidateExperiencesBusiness : ICandidateExperiencesBusiness
    {
        private readonly ICandidateExperienceRepository _repository;

        public CandidateExperiencesBusiness(ICandidateExperienceRepository repository)
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

        public CandidateExperience Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidateExperience> GetByCandidate(int candidateID)
        {
            return _repository.GetByCandidate(candidateID);
        }

        public int Save(CandidateExperience candidateExperiences)
        {
            return _repository.Save(candidateExperiences);
        }
    }
}
