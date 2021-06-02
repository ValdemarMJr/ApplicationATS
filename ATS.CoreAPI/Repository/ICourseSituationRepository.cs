using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public interface ICourseSituationRepository
    {
        CourseSituation Get(int id);

        CourseSituation GetByName(string name);

        List<CourseSituation> GetAll();

        List<CourseSituation> GetOnlyActives();

        int Save(CourseSituation courseSituation);
    
        bool Delete(int id);
    }
}
