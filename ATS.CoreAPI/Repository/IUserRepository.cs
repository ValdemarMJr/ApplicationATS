using ATS.CoreAPI.Model.DTO;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserDTO user);
        User ValidateCredentials(string userName);
        User RefreshUserInfo(User user);
        bool RevokeToken(string userName);
        bool Exists(int id);
        User Get(int id);
        User GetByCPF(string cpf);
        User GetByEmail(string email);
        User GetByUserName(string userName);
        int Save(User user);
        bool Delete(int id);
        bool RegisteredUser(string cpf);
        bool UpdatePassword(int id, string password);

    }
}
