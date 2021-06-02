using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidateRoleBusiness : ICandidateRoleBusiness
    {
        private readonly ICandidateRoleRepository _repository;

        public CandidateRoleBusiness(ICandidateRoleRepository repository)
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

        public CandidateRole Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidateRole> GetByCandidate(int candidateID)
        {
            return _repository.GetByCandidate(candidateID);
        }

        public int Save(CandidateRole candidateRole)
        {
            return _repository.Save(candidateRole);
        }
    }
}
