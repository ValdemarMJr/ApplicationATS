using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class ImprovementCourse
    {
        public ImprovementCourse()
        {
            CandidateImprovementCourses = new HashSet<CandidateImprovementCourse>();
        }

        public int CdImprovementCourses { get; set; }
        public string DsImprovementCourses { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<CandidateImprovementCourse> CandidateImprovementCourses { get; set; }
    }
}
