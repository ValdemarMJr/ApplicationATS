using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class Gender
    {
        public Gender()
        {
            Candidates = new HashSet<Candidate>();
        }

        public int CdGender { get; set; }
        public string DsGender { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
