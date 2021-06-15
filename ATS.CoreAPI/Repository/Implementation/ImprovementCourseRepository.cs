using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class ImprovementCourseRepository : IImprovementCourseRepository
    {
        private readonly SQLContext _context;

        public ImprovementCourseRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var improvementCourse = _context.ImprovementCourses.FirstOrDefault(i => i.ID == id);
            if (improvementCourse is null)
                throw new ImprovementCourseNotExistsException();
            else
            {
                _context.ImprovementCourses.Remove(improvementCourse);
                _context.SaveChanges();
                return true;
            }
        }

        public ImprovementCourse Get(int id)
        {
            var improvementCourse = _context.ImprovementCourses.FirstOrDefault(i => i.ID == id);
            if (improvementCourse is null)
                throw new ImprovementCourseNotExistsException();
            else
            {
                return improvementCourse;
            }
        }

        public List<ImprovementCourse> GetAll()
        {
            return _context.ImprovementCourses.ToList();
        }

        public ImprovementCourse GetByName(string name)
        {
            var improvementCourse = _context.ImprovementCourses.FirstOrDefault(i => i.Name == name);
            if (improvementCourse is null)
                throw new ImprovementCourseNotExistsException();
            else
            {
                return improvementCourse;
            }
        }

        public List<ImprovementCourse> GetOnlyActives()
        {
            return _context.ImprovementCourses.Where(i => i.Inactive == false).ToList();
        }

        public int Save(ImprovementCourse improvementCourse)
        {
            int improvementCourseID = 0;
            var improvementCourseContext = _context.ImprovementCourses.FirstOrDefault(s => s.Name == improvementCourse.Name);

            if (improvementCourse.Name == null || String.IsNullOrEmpty(improvementCourse.Name))
                throw new NameRequiredException();
            else
            {
                if (improvementCourseContext is null)
                {
                    _context.ImprovementCourses.Add(improvementCourse);
                    _context.SaveChanges();

                    improvementCourseID = improvementCourse.ID;
                }
                else
                {
                    improvementCourseContext.Name = improvementCourse.Name;
                    improvementCourseContext.Inactive = improvementCourse.Inactive;

                    _context.SaveChanges();

                    improvementCourseID = improvementCourseContext.ID;
                }
            }

            return improvementCourseID;
        }
    }
}
