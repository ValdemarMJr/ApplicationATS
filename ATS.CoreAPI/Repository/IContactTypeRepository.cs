using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IContactTypeRepository
    {
        ContactType Get(int id);

        ContactType GetByName(string name);

        List<ContactType> GetAll();

        List<ContactType> GetOnlyActives();

        int Save(ContactType contactType);

        bool Delete(int id);
    }
}
