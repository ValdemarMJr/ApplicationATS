using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class JobOpportunityBusiness : IJobOpportunityBusiness
    {
        private readonly IJobOpportunityRepository _repository;

        public JobOpportunityBusiness(IJobOpportunityRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public JobOpportunity Get(int id)
        {
            return _repository.Get(id);
        }

        public List<JobOpportunity> GetAll()
        {
            return _repository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public JobOpportunity GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<JobOpportunity> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(c => c.Name).ToList();
        }

        public int Save(JobOpportunity jobOpportunity)
        {
            return _repository.Save(jobOpportunity);
        }
    }
}
