using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("CandidateRole")]
    public class CandidateRole
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CandidateID")]
        public int CandidateID { get; set; }

        [Column("RoleID")]
        public int RoleID { get; set; }

        public Role Role { get; set; }
    }
}
