using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class PersonalReference
    {
        public PersonalReference()
        {
            CandidatePersonalReferences = new HashSet<CandidatePersonalReference>();
        }

        public int CdPersonalReference { get; set; }
        public int CdPersonalReferenceType { get; set; }
        public string DsName { get; set; }
        public string DsTelephone { get; set; }

        public virtual ICollection<CandidatePersonalReference> CandidatePersonalReferences { get; set; }
    }
}
