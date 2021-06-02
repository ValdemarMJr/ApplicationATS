using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class ImprovementCourseBusiness : IImprovementCourseBusiness
    {
        private readonly IImprovementCourseRepository _repository;

        public ImprovementCourseBusiness(IImprovementCourseRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public ImprovementCourse Get(int id)
        {
            return _repository.Get(id);
        }

        public List<ImprovementCourse> GetAll()
        {
            return _repository.GetAll().OrderBy(i => i.Name).ToList();
        }

        public ImprovementCourse GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<ImprovementCourse> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(i => i.Name).ToList();
        }

        public int Save(ImprovementCourse improvementCourse)
        {
            return _repository.Save(improvementCourse);
        }
    }
}
