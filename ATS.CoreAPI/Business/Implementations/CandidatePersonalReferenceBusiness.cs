using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidatePersonalReferenceBusiness : ICandidatePersonalReferenceBusiness
    {
        private readonly ICandidatePersonalReferenceRepository _repository;

        public CandidatePersonalReferenceBusiness(ICandidatePersonalReferenceRepository repository)
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

        public CandidatePersonalReference Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidatePersonalReference> GetByCandidate(int candidateID)
        {
            return _repository.GetByCandidate(candidateID);
        }

        public int Save(CandidatePersonalReference candidatePersonalReference)
        {
            return _repository.Save(candidatePersonalReference);
        }
    }
}
