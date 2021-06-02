using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class AcademicEducation
    {
        public AcademicEducation()
        {
            CandidateAcademicEducations = new HashSet<CandidateAcademicEducation>();
        }

        public int CdAcademicEducation { get; set; }
        public string DsCourse { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<CandidateAcademicEducation> CandidateAcademicEducations { get; set; }
    }
}
