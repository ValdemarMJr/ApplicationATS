using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Exceptions
{
    public class ContactNotExistsException : Exception
    {
    }

    public class ContactNameIsRequiredException : Exception
    {
    }

    public class ContactInformationIsRequiredException : Exception
    {
    }

    public class ContactTypeIsRequiredException : Exception
    {
    }

    public class ContactTypeIsInvalidException : Exception
    {
    }
}
