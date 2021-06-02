using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("PersonalReference")]
    public class PersonalReference
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Telephone")]
        public string Telephone { get; set; }

        [Column("PersonalReferenceTypeID")]

        public int PersonalReferenceTypeID { get; set; }

        public PersonalReferenceType PersonalReferenceType { get; set; }
    }
}
