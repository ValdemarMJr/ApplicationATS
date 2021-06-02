using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class CourseSituationBusiness : ICourseSituationBusiness
    {
        private readonly ICourseSituationRepository _repository;

        public CourseSituationBusiness(ICourseSituationRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public CourseSituation Get(int id)
        {
            return _repository.Get(id);
        }

        public List<CourseSituation> GetAll()
        {
            return _repository.GetAll().OrderBy(c => c.Name).ToList();
        }

        public CourseSituation GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<CourseSituation> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(c => c.Name).ToList();
        }

        public int Save(CourseSituation courseSituation)
        {
            return _repository.Save(courseSituation);
        }
    }
}
