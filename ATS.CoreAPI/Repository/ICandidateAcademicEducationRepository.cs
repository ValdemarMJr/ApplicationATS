using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICandidateAcademicEducationRepository
    {
        CandidateAcademicEducation Get(int id);

        List<CandidateAcademicEducation> GetByCandidate(int candidateID);

        int Save(CandidateAcademicEducation candidateAcademicEducation);

        bool Delete(int id);

        bool DeleteByCandidateID(int candidateID);


    }
}
