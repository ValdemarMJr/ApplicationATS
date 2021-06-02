using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IGenderRepository
    {
        Gender Get(int id);

        Gender GetByName(string name);

        List<Gender> GetAll();

        List<Gender> GetOnlyActives();

        int Save(Gender gender);

        bool Delete(int id);
    }
}
