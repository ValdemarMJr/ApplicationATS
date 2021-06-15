using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface ICandidateBusiness
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

        int SaveCandidateImprovmentCourse(CandidateImprovementCourse candidateImprovmentCourse);

        int SaveCandidateAcademicEducation(CandidateAcademicEducation candidateAcademicEducation);

        int SaveCandidateExperiences(CandidateExperience candidateExperience);

        int SaveCandidatePersonalReferences(CandidatePersonalReference candidatePersonalReference);

        int SaveCandidateRoles(CandidateRole candidateRole);

        bool Delete(int id);
    }
}
