using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class Candidate
    {
        public Candidate()
        {
            CandidateAcademicEducations = new HashSet<CandidateAcademicEducation>();
            CandidateAddresses = new HashSet<CandidateAddress>();
            CandidateContacts = new HashSet<CandidateContact>();
            CandidateImprovementCourses = new HashSet<CandidateImprovementCourse>();
            CandidatePersonalReferences = new HashSet<CandidatePersonalReference>();
            CandidateRoles = new HashSet<CandidateRole>();
        }

        public int CdCandidate { get; set; }
        public string DsName { get; set; }
        public string DsSurname { get; set; }
        public DateTime DtBirth { get; set; }
        public string DsCpf { get; set; }
        public string DsRg { get; set; }
        public string DsCarteiraTrabalho { get; set; }
        public string DsSerieCarteiraTrabalho { get; set; }
        public int? CdUfcarteiraTrabalho { get; set; }
        public string DsCnh { get; set; }
        public string DsCategoriaCnh { get; set; }
        public DateTime? DtVencCnh { get; set; }
        public string Password { get; set; }
        public string DsEmail { get; set; }
        public int CdGender { get; set; }
        public int CdNacionality { get; set; }
        public int CdPlaceOfBirth { get; set; }
        public int CdCivilStatus { get; set; }

        public virtual CivilStatus CdCivilStatusNavigation { get; set; }
        public virtual Gender CdGenderNavigation { get; set; }
        public virtual State CdNacionalityNavigation { get; set; }
        public virtual State CdUfcarteiraTrabalhoNavigation { get; set; }
        public virtual ICollection<CandidateAcademicEducation> CandidateAcademicEducations { get; set; }
        public virtual ICollection<CandidateAddress> CandidateAddresses { get; set; }
        public virtual ICollection<CandidateContact> CandidateContacts { get; set; }
        public virtual ICollection<CandidateImprovementCourse> CandidateImprovementCourses { get; set; }
        public virtual ICollection<CandidatePersonalReference> CandidatePersonalReferences { get; set; }
        public virtual ICollection<CandidateRole> CandidateRoles { get; set; }
    }
}
