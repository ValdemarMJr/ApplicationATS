using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IContactRepository
    {
        Contact Get(int id);

        List<Contact> GetAll();

        int Save(Contact contact);

        bool Delete(int id);
    }
}
