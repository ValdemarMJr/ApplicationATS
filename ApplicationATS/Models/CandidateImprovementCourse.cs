using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidateImprovementCourse
    {
        public int CdCandidateImprovementCourse { get; set; }
        public int CdCandidate { get; set; }
        public int CdImprovementCourse { get; set; }
        public int CdSituationCourse { get; set; }
        public DateTime? DtStart { get; set; }
        public DateTime? DtFinish { get; set; }

        public virtual Candidate CdCandidateNavigation { get; set; }
        public virtual ImprovementCourse CdImprovementCourseNavigation { get; set; }
        public virtual CourseSituation CdSituationCourseNavigation { get; set; }
    }
}
