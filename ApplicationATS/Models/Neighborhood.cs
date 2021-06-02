using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class Neighborhood
    {
        public int CdNeighborhood { get; set; }
        public string DsNeighborhood { get; set; }
        public bool StInactive { get; set; }
        public int CdCity { get; set; }
    }
}
