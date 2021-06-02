using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidateContactBusiness : ICandidateContactBusiness
    {
        private readonly ICandidateContactRepository _repository;

        public CandidateContactBusiness(ICandidateContactRepository repository)
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

        public CandidateContact Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidateContact> GetByCandidate(int candidateID)
        {
            return _repository.GetByCandidate(candidateID);
        }

        public int Save(CandidateContact candidateContact)
        {
            return _repository.Save(candidateContact);
        }
    }
}
