using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class State
    {
        public State()
        {
            CandidateCdNacionalityNavigations = new HashSet<Candidate>();
            CandidateCdUfcarteiraTrabalhoNavigations = new HashSet<Candidate>();
            Cities = new HashSet<City>();
        }

        public int CdState { get; set; }
        public string DsName { get; set; }
        public string DsShorName { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<Candidate> CandidateCdNacionalityNavigations { get; set; }
        public virtual ICollection<Candidate> CandidateCdUfcarteiraTrabalhoNavigations { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
