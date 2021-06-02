using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class City
    {
        public int CdCity { get; set; }
        public string DsCity { get; set; }
        public int CdState { get; set; }
        public bool StInactive { get; set; }

        public virtual State CdStateNavigation { get; set; }
    }
}
