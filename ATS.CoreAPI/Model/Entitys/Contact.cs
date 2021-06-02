using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("Contact")]
    public class Contact
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Information")]
        public string Information { get; set; }

        [Column("ContactTypeID")]
        public int ContactTypeID { get; set; }

        public ContactType ContactType { get; set; }
    }
}
