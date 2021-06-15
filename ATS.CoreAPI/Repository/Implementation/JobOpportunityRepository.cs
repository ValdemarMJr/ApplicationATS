using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class JobOpportunityRepository : IJobOpportunityRepository
    {
        private readonly SQLContext _context;

        public JobOpportunityRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var jobOpportunity = _context.JobOpportunities.FirstOrDefault(s => s.ID == id);
            if (jobOpportunity is null)
                throw new JobOpportunityNotExistisException();
            else
            {
                _context.JobOpportunities.Remove(jobOpportunity);
                _context.SaveChanges();
                return true;
            }
        }

        public JobOpportunity Get(int id)
        {
            var jobOpportunity = _context.JobOpportunities.FirstOrDefault(s => s.ID == id);
            if (jobOpportunity is null)
                throw new JobOpportunityNotExistisException();
            else
            {
                return jobOpportunity;
            }
        }

        public List<JobOpportunity> GetAll()
        {
            return _context.JobOpportunities.ToList();
        }

        public JobOpportunity GetByName(string name)
        {
            var jobOpportunity = _context.JobOpportunities.FirstOrDefault(s => s.Name == name);
            if (jobOpportunity is null)
                throw new JobOpportunityNotExistisException();
            else
            {
                return jobOpportunity;
            }
        }

        public List<JobOpportunity> GetOnlyActives()
        {
            return _context.JobOpportunities.Where(s => s.Inactive == false).ToList();
        }

        public int Save(JobOpportunity jobOpportunity)
        {
            int jobOpportunityID = 0;
            var jobOpportunityContext = _context.JobOpportunities.FirstOrDefault(j => j.Name == jobOpportunity.Name);

            if (jobOpportunity.Name == null || String.IsNullOrEmpty(jobOpportunity.Name))
                throw new NameRequiredException();
            else
            {
                if (jobOpportunityContext is null)
                {
                    _context.JobOpportunities.Add(jobOpportunity);
                    _context.SaveChanges();

                    jobOpportunityID = jobOpportunity.ID;
                }
                else
                {
                    jobOpportunityContext.Name = jobOpportunity.Name;
                    jobOpportunityContext.Inactive = jobOpportunity.Inactive;

                    _context.SaveChanges();

                    jobOpportunityID = jobOpportunityContext.ID;

                }
            }

            return jobOpportunityID;
        }
    }
}
