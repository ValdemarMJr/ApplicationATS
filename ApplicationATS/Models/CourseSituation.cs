using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class CourseSituation
    {
        public CourseSituation()
        {
            CandidateAcademicEducations = new HashSet<CandidateAcademicEducation>();
            CandidateImprovementCourses = new HashSet<CandidateImprovementCourse>();
        }

        public int CdSituationCourse { get; set; }
        public string DsSituationCourse { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<CandidateAcademicEducation> CandidateAcademicEducations { get; set; }
        public virtual ICollection<CandidateImprovementCourse> CandidateImprovementCourses { get; set; }
    }
}
