using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidateRole
    {
        public int CdCandidateRole { get; set; }
        public int CdCandidate { get; set; }
        public int CdRole { get; set; }

        public virtual Candidate CdCandidateNavigation { get; set; }
        public virtual Role CdRoleNavigation { get; set; }
    }
}
