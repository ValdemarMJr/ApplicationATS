using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Business
{
    public interface IAcademicsEducationBusiness
    {
        AcademicEducation Get(int id);

        AcademicEducation GetByName(string name);

        List<AcademicEducation> GetAll();

        List<AcademicEducation> GetOnlyActives();

        int Save(AcademicEducation academicEducation);

        bool Delete(int id);
    }
}
