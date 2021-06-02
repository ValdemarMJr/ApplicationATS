using ATS.CoreAPI.Model.DTO;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Exceptions
{
    public class InactiveUserException : Exception
    {
    }

    public class EmailRequiredException : Exception
    {
    }

    public class CPFRequiredException : Exception
    {
    }

    public class PasswordRequiredException : Exception
    {
    }

    public class UserNotExistsException : Exception
    {
    }

    public class UserPasswordNotSetException : Exception
    {
        public User User;
        public TokenDTO UserTempToken;
        public UserPasswordNotSetException(User user)
        {
            User = user;
        }
        public UserPasswordNotSetException(TokenDTO token)
        {
            UserTempToken = token;
        }
    }

    public class UserNameRequiredException : Exception
    {
    }

    public class UserAlreadyRegisteredException : Exception
    {
    }
}
