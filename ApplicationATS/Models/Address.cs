using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class Address
    {
        public Address()
        {
            CandidateAddresses = new HashSet<CandidateAddress>();
        }

        public int CdAddress { get; set; }
        public string DsZipCode { get; set; }
        public string DsStreet { get; set; }
        public string DsNumber { get; set; }
        public string DsComplement { get; set; }
        public string DsReferencePoint { get; set; }
        public int CdNeighborhood { get; set; }
        public bool StDefault { get; set; }

        public virtual ICollection<CandidateAddress> CandidateAddresses { get; set; }
    }
}
