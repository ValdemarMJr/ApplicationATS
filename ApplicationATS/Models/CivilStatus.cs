using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CivilStatus
    {
        public CivilStatus()
        {
            Candidates = new HashSet<Candidate>();
        }

        public int CdCivilStatus { get; set; }
        public string DsCivilStatus { get; set; }
        public string StInactive { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
