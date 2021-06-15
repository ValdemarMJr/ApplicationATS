using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class AcademicEducationRespository : IAcademicEducationRepository
    {
        private readonly SQLContext _context;

        public AcademicEducationRespository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var academicEducation = _context.AcademicsEducation.FirstOrDefault(s => s.ID == id);
            if (academicEducation is null)
                throw new AcademicsEducationNotExistsException();
            else
            {
                _context.AcademicsEducation.Remove(academicEducation);
                _context.SaveChanges();
                return true;
            }
        }

        public AcademicEducation Get(int id)
        {
            var academicEducation = _context.AcademicsEducation.FirstOrDefault(s => s.ID == id);
            if (academicEducation is null)
                throw new AcademicsEducationNotExistsException();
            else
            {
                return academicEducation;
            }
        }

        public List<AcademicEducation> GetAll()
        {
            return _context.AcademicsEducation.ToList();
        }

        public AcademicEducation GetByName(string name)
        {
            var academicEducation = _context.AcademicsEducation.FirstOrDefault(s => s.Name == name);
            if (academicEducation is null)
                throw new AcademicsEducationNotExistsException();
            else
            {
                return academicEducation;
            }
        }

        public List<AcademicEducation> GetOnlyActives()
        {
            return _context.AcademicsEducation.Where(s => s.Inactive == false).ToList();
        }

        public int Save(AcademicEducation academicEducation)
        {
            int academicEducationID = 0;
            var academicEducationContext = _context.AcademicsEducation.FirstOrDefault(s => s.Name == academicEducation.Name);

            if (academicEducation.Name == null || String.IsNullOrEmpty(academicEducation.Name))
                throw new NameRequiredException();
            else
            {
                if (academicEducationContext is null)
                {
                    _context.AcademicsEducation.Add(academicEducation);
                    _context.SaveChanges();

                    academicEducationID = academicEducation.ID;
                }
                else
                {
                    academicEducationContext.Name = academicEducation.Name;
                    academicEducationContext.Inactive = academicEducation.Inactive;

                    _context.SaveChanges();

                    academicEducationID = academicEducationContext.ID;

                }
            }

            return academicEducationID;
        }
    }
}
