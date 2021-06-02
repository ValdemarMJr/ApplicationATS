using System.ComponentModel.DataAnnotations.Schema;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ATS.CoreAPI.Model.Entitys
{
    [Table("User")]

    public class User
    {
        [Key]
        [Column("ID")]
        public int ID { get; set; }

        [Column("UserName")]
        public string UserName { get; set; }

        [Column("Password")]
        public string? Password { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("CPF")]
        public string CPF { get; set; }

        [Column("Inactive", TypeName = "bit")]
        public bool Inactive { get; set; }

        [NotMapped]
        public string? RefreshToken { get; set; }

        [NotMapped]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
