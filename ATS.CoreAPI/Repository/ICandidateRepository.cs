using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICandidateRepository
    {
        Candidate Get(int id);

        Candidate GetByCPF(string CPF);

        Candidate GetByEmail(string email);

        List<CandidateContact> GetContactsByCandidate(int candidateID);

        List<CandidatePersonalReference> GetPersonalReferencesByCandidate(int candidateID);

        List<CandidateAcademicEducation> GetAcademicEducationByCandidate(int candidateID);

        List<CandidateImprovementCourse> GetImprovmentCoursesByCandidate(int candidateID);

        List<CandidateExperience> GetExperiencesByCandidate(int candidateID);

        List<CandidateRole> GetRolesByCandidate(int candidateID);

        int Save(Candidate candidate);

        bool Delete(int id);
    }
}
