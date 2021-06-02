using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface IAddressBusiness
    {
        Address Get(int id);

        List<Address> GetAll();

        int Save(Address address);

        bool Delete(int id);
    }
}
