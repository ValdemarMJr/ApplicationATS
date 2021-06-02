using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICandidateContactRepository
    {
        CandidateContact Get(int id);

        List<CandidateContact> GetByCandidate(int candidateID);

        int Save(CandidateContact candidateContact);

        bool Delete(int id);

        bool DeleteByCandidateID(int candidateID);
    }
}
