using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("ZipCode")]
        public string ZipCode { get; set; }

        [Column("Street")]
        public string Street { get; set; }

        [Column("Number")]
        public string Number { get; set; }

        [Column("Complement")]
        public string Complement { get; set; }

        [Column("ReferencePoint")]
        public string ReferencePoint { get; set; }

        [Column("NeighborhoodID")]
        public int NeighborhoodID { get; set; }

        public Neighborhood Neighborhood { get; set; }


    }
}
