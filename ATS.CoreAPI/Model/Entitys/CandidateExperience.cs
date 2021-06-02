using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("CandidateExperiences")]
    public class CandidateExperience
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Company")]
        public string Company { get; set; }

        [Column("CandidateID")]
        public int CandidateID { get; set; }

        [Column("DtAdmission")]
        public DateTime? DtAdmission { get; set; }

        [Column("DtResignation")]
        public DateTime? DtResignation { get; set; }

        [Column("Activities")]
        public string Activities { get; set; }



    }
}
