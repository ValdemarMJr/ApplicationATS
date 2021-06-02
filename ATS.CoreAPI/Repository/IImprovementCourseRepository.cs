using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface IImprovementCourseRepository
    {
        ImprovementCourse Get(int id);

        ImprovementCourse GetByName(string name);

        List<ImprovementCourse> GetAll();

        List<ImprovementCourse> GetOnlyActives();

        int Save(ImprovementCourse improvementCourse);

        bool Delete(int id);
    }
}
