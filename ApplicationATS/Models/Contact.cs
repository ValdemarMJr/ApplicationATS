using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class Contact
    {
        public Contact()
        {
            CandidateContacts = new HashSet<CandidateContact>();
        }

        public int CdContact { get; set; }
        public string DsContactName { get; set; }
        public string DsContact { get; set; }
        public int CdContactType { get; set; }
        public bool StDefault { get; set; }

        public virtual ContactType CdContactTypeNavigation { get; set; }
        public virtual ICollection<CandidateContact> CandidateContacts { get; set; }
    }
}
