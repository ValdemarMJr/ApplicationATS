using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business.Implementations
{
    public class AcademicEducationBusiness : IAcademicsEducationBusiness
    {
        private readonly IAcademicEducationRepository _repository;

        public AcademicEducationBusiness(IAcademicEducationRepository repository)
        {
            _repository = repository;
        }
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public AcademicEducation Get(int id)
        {
            return _repository.Get(id);
        }

        public List<AcademicEducation> GetAll()
        {
            return _repository.GetAll().OrderBy(a => a.Name).ToList();
        }

        public AcademicEducation GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public List<AcademicEducation> GetOnlyActives()
        {
            return _repository.GetOnlyActives().OrderBy(a => a.Name).ToList();
        }

        public int Save(AcademicEducation academicEducation)
        {
            return _repository.Save(academicEducation);
        }
    }
}
