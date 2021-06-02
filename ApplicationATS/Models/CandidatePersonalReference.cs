using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidatePersonalReference
    {
        public int CdCandidatePersonalReference { get; set; }
        public int CdCandidate { get; set; }
        public int CdPersonalReference { get; set; }

        public virtual Candidate CdCandidateNavigation { get; set; }
        public virtual PersonalReference CdPersonalReferenceNavigation { get; set; }
    }
}
