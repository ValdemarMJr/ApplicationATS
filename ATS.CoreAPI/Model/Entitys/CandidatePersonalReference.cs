using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("CandidatePersonalReference")]
    public class CandidatePersonalReference
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CandidateID")]
        public int CandidateID { get; set; }

        [Column("PersonalReferenceID")]
        public int PersonalReferenceID { get; set; }

        public PersonalReference PersonalReference { get; set; }
    }
}
