using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("JobOpportunity")]
    public class JobOpportunity
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Inactive", TypeName = "bit")]
        public bool Inactive { get; set; }

        [Column("Requirements")]
        public string? Requirements { get; set; }

        [Column("Assignments")]
        public string? Assignments { get; set; }

        [Column("Benefits")]
        public string? Benefits { get; set; }
    }
}
