using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IPersonalReferenceTypeRepository
    {
        PersonalReferenceType Get(int id);

        PersonalReferenceType GetByName(string name);

        List<PersonalReferenceType> GetAll();

        List<PersonalReferenceType> GetOnlyActives();

        int Save(PersonalReferenceType contactType);

        bool Delete(int id);
    }
}
