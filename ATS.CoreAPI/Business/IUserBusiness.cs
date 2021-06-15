using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Bussiness
{
    public interface IUserBusiness
    {
        User Get(int pID);

        User GetByCPF(string pCPF);

        User GetByEmail(string email);

        User GetByUserName(string userName);

        int Save(User pUser);

        bool Delete(int pID);

        bool UpdatePassword(int pID, string pPassword);
    }
}
