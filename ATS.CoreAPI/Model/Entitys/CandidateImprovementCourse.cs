using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("CandidateImprovementCourse")]
    public class CandidateImprovementCourse
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CandidateID")]
        public int CandidateID { get; set; }

        [Column("ImprovementCourseID")]
        public int ImprovementCourseID { get; set; }

        public ImprovementCourse ImprovementCourse { get; set; }

        [Column("SituationCourseID")]
        public int SituationCourseID { get; set; }

        public CourseSituation SituationCourse { get; set; }

        [Column("DtStart")]
        public DateTime? DtStart { get; set; }

        [Column("DtFinish")]
        public DateTime? DtFinish { get; set; }


    }
}
