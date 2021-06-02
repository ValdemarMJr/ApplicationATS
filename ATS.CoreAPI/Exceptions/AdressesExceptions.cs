using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Exceptions
{
    public class AddressNotExistsException : Exception
    {
    }

    public class ZipcodeIsRequiredException : Exception
    {
    }

    public class NumberIsRequiredException : Exception
    {
    }

    public class StreetIsRequiredException : Exception
    {
    }

    public class NeighborhoodIsRequiredException : Exception
    {
    }

    public class NeighborhoodIsInvalidException : Exception
    {
    }
}
