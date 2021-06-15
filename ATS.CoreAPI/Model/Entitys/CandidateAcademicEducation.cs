using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("CandidateAcademicEducation")]
    public class CandidateAcademicEducation
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CandidateID")]
        public int CandidateID { get; set; }

        [Column("AcademicEducationID")]
        public int AcademicEducationID { get; set; }

        public AcademicEducation AcademicEducation { get; set; }

        [Column("SituationCourseID")]
        public int SituationCourseID { get; set; }

        [NotMapped]
        public CourseSituation CourseSituation { get; set; }

        [Column("DtStart")]
        public DateTime? DtStart { get; set; }

        [Column("DtFinish")]
        public DateTime? DtFinish { get; set; }

    }
}
