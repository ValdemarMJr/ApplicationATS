using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("Candidate")]
    public class Candidate
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("UserID")]
        public int UserID { get; set; }

        public User User { get; set; }

        [Column("BirthDate")]
        public DateTime BirthDate { get; set; }

        [Column("RG")]
        public string RG { get; set; }

        [Column("CarteiraTrabalho")]
        public string CarteiraTrabalho { get; set; }

        [Column("SerieCarteiraTrabalho")]
        public string SerieCarteiraTrabalho { get; set; }

        [Column("CNH")]
        public string CNH { get; set; }

        [Column("CategoriaCNH")]
        public string CategoriaCNH { get; set; }

        [Column("VencCNH")]
        public DateTime ExpirationDateCNH { get; set; }

        [Column("GenderID")]
        public int GenderID { get; set; }

        public Gender Gender { get; set; }

        [Column("AddressID")]
        public int AddressID { get; set; }

        public Address Address { get; set; }

        [Column("PlaceOfBirthID")]
        public int PlaceOfBirthID { get; set; }

        [NotMapped]
        public City PlaceOfBirth { get; set; }

        [Column("CivilStateID")]
        public int CivilStateID { get; set; }
        
        [NotMapped]
        public CivilState CivilState { get; set; }

        public List<CandidateAcademicEducation> AcademicsEducation { get; set; }

        public List<CandidateContact> Contacts { get; set; }

        public List<CandidateExperience> Experiences { get; set; }

        public List<CandidateImprovementCourse> ImprovementCourses { get; set; }

        public List<CandidatePersonalReference> PersonalReferences { get; set; }

        public List<CandidateRole> Roles { get; set; }
    }
}
