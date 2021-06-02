using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class JobOpportunity
    {
        public int CdJobOpportunity { get; set; }
        public string DsJobOpportunity { get; set; }
        public bool StInactive { get; set; }
        public string DsRequirements { get; set; }
        public string DsAssignments { get; set; }
        public string DsBenefits { get; set; }
    }
}
