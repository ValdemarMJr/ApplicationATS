using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CandidateBusiness : ICandidateBusiness
    {
        private readonly ICandidateRepository _repository;

        public CandidateBusiness(ICandidateRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public Candidate Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CandidateAcademicEducation> GetAcademicEducationByCandidate(int candidateID)
        {
            return _repository.GetAcademicEducationByCandidate(candidateID);
        }

        public Candidate GetByCPF(string CPF)
        {
            return _repository.GetByCPF(CPF);
        }

        public Candidate GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public List<CandidateContact> GetContactsByCandidate(int candidateID)
        {
            return _repository.GetContactsByCandidate(candidateID);
        }

        public List<CandidateExperience> GetExperiencesByCandidate(int candidateID)
        {
            return _repository.GetExperiencesByCandidate(candidateID);
        }

        public List<CandidateImprovementCourse> GetImprovmentCoursesByCandidate(int candidateID)
        {
            return _repository.GetImprovmentCoursesByCandidate(candidateID);
        }

        public List<CandidatePersonalReference> GetPersonalReferencesByCandidate(int candidateID)
        {
            return _repository.GetPersonalReferencesByCandidate(candidateID);
        }

        public List<CandidateRole> GetRolesByCandidate(int candidateID)
        {
            return _repository.GetRolesByCandidate(candidateID);
        }

        public int Save(Candidate candidate)
        {
            return _repository.Save(candidate);
        }

        public int SaveCandidateAcademicEducation(CandidateAcademicEducation candidateAcademicEducation)
        {
            return _repository.SaveCandidateAcademicEducation(candidateAcademicEducation);
        }

        public int SaveCandidateExperiences(CandidateExperience candidateExperience)
        {
            return _repository.SaveCandidateExperiences(candidateExperience);
        }

        public int SaveCandidateImprovmentCourse(CandidateImprovementCourse candidateImprovmentCourse)
        {
            return _repository.SaveCandidateImprovmentCourse(candidateImprovmentCourse);
        }

        public int SaveCandidatePersonalReferences(CandidatePersonalReference candidatePersonalReference)
        {
            return _repository.SaveCandidatePersonalReferences(candidatePersonalReference);
        }

        public int SaveCandidateRoles(CandidateRole candidateRole)
        {
            return _repository.SaveCandidateRoles(candidateRole);
        }
    }
}
