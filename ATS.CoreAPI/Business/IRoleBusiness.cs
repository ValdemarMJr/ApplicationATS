using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface IRoleBusiness
    {
        Role Get(int id);

        Role GetByName(string name);

        List<Role> GetAll();

        List<Role> GetOnlyActives();

        int Save(Role role);

        bool Delete(int id);
    }
}
