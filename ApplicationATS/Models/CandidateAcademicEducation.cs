using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CandidateAcademicEducation
    {
        public int CdCandidateAcademicEducation { get; set; }
        public int CdCandidate { get; set; }
        public int CdAcademicEducation { get; set; }
        public int CdSituationCourse { get; set; }
        public DateTime? DtStart { get; set; }
        public DateTime? DtFinish { get; set; }

        public virtual AcademicEducation CdAcademicEducationNavigation { get; set; }
        public virtual Candidate CdCandidateNavigation { get; set; }
        public virtual CourseSituation CdSituationCourseNavigation { get; set; }
    }
}
