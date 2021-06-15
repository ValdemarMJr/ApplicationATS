using ATS.CoreAPI.Model.DTO;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Bussiness
{
    public interface ILoginBusiness
    {
        TokenDTO ValidateCredentials(UserDTO userCredentials);
        TokenDTO ValidateCredentials(TokenDTO token);
        TokenDTO GenerateTemporaryCredentials(User user);
        bool RevokeToken(string userName);
    }
}
