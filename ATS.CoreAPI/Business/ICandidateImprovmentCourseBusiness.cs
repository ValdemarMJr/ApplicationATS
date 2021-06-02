using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface ICandidateImprovmentCourseBusiness
    {
        CandidateImprovementCourse Get(int id);

        List<CandidateImprovementCourse> GetByCandidate(int candidateID);

        int Save(CandidateImprovementCourse candidateImprovementCourse);

        bool Delete(int id);

        bool DeleteByCandidateID(int candidateID);
    }
}
