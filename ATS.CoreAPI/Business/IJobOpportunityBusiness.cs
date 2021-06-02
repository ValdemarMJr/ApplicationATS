using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface IJobOpportunityBusiness
    {
        JobOpportunity Get(int id);

        JobOpportunity GetByName(string name);

        List<JobOpportunity> GetAll();

        List<JobOpportunity> GetOnlyActives();

        int Save(JobOpportunity jobOpportunity);

        bool Delete(int id);
    }
}
