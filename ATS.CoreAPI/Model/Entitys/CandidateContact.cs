using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("CandidateContact")]
    public class CandidateContact
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("CandidateID")]
        public int CandidateID { get; set; }

        [Column("ContactID")]
        public int ContactID { get; set; }

        public Contact Contact { get; set; }
    }
}
