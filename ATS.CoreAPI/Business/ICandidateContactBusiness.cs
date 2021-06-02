using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface ICandidateContactBusiness
    {
        CandidateContact Get(int id);
        List<CandidateContact> GetByCandidate(int candidateID);

        int Save(CandidateContact candidateContact);

        bool Delete(int id);

        bool DeleteByCandidateID(int id);
    }
}
