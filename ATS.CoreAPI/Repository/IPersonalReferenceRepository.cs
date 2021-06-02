using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IPersonalReferenceRepository
    {
        PersonalReference Get(int id);

        List<PersonalReference> GetAll();

        int Save(PersonalReference personalReference);

        bool Delete(int id);
    }
}
