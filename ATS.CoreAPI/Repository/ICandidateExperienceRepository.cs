using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICandidateExperienceRepository
    {
        CandidateExperience Get(int id);

        List<CandidateExperience> GetByCandidate(int candidateID);

        int Save(CandidateExperience candidateExperiences);

        bool Delete(int id);

        bool DeleteByCandidateID(int candidateID);
    }
}
