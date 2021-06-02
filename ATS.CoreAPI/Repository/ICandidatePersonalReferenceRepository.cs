using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICandidatePersonalReferenceRepository
    {
        CandidatePersonalReference Get(int id);

        List<CandidatePersonalReference> GetByCandidate(int candidateID);

        int Save(CandidatePersonalReference candidatePersonalReference);

        bool Delete(int id);

        bool DeleteByCandidateID(int candidateID);
    }
}
