using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("City")]
    public class City
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("StateID")]
        public int StateID { get; set; }

        [Column("Inactive", TypeName = "bit")]
        public bool Inactive { get; set; }

        public State State { get; set; }
    }
}
    
