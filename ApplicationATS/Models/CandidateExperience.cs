using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidateExperience
    {
        public int CdCandidateExperiences { get; set; }
        public string DsCompany { get; set; }
        public DateTime DtAdmission { get; set; }
        public DateTime DtResignation { get; set; }
        public string DsActivities { get; set; }
    }
}
