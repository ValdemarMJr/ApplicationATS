using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class Role
    {
        public Role()
        {
            CandidateRoles = new HashSet<CandidateRole>();
        }

        public int CdRole { get; set; }
        public string DsRole { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<CandidateRole> CandidateRoles { get; set; }
    }
}
