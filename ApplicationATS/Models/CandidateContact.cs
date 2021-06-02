using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidateContact
    {
        public int CdCandidateContact { get; set; }
        public int CdContact { get; set; }
        public int CdCandidate { get; set; }

        public virtual Candidate CdCandidateNavigation { get; set; }
        public virtual Contact CdContactNavigation { get; set; }
    }
}
