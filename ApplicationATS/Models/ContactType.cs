using System;
using System.Collections.Generic;

#nullable disable

namespace ApplicationATS.Models
{
    public partial class ContactType
    {
        public ContactType()
        {
            Contacts = new HashSet<Contact>();
        }

        public int CdContactType { get; set; }
        public string DsContactType { get; set; }
        public bool StInactive { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
