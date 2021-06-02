using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidateAddress
    {
        public int CdCandidateAddress { get; set; }
        public int CdAddress { get; set; }
        public int CdCandidate { get; set; }

        public virtual Address CdAddressNavigation { get; set; }
        public virtual Candidate CdCandidateNavigation { get; set; }
    }
}
