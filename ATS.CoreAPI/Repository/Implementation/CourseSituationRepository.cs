using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class CourseSituationRepository : ICourseSituationRepository
    {
        private readonly SQLContext _context;

        public CourseSituationRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var courseSituation = _context.CourseSituations.FirstOrDefault(s => s.ID == id);
            if (courseSituation is null)
                throw new CourseSituationNotExistsException();
            else
            {
                _context.CourseSituations.Remove(courseSituation);
                _context.SaveChanges();
                return true;
            }
        }

        public CourseSituation Get(int id)
        {
            var courseSituation = _context.CourseSituations.FirstOrDefault(s => s.ID == id);
            if (courseSituation is null)
                throw new CourseSituationNotExistsException();
            else
            {
                return courseSituation;
            }
        }

        public List<CourseSituation> GetAll()
        {
            return _context.CourseSituations.ToList();
        }

        public CourseSituation GetByName(string name)
        {
            var courseSituation = _context.CourseSituations.FirstOrDefault(c => c.Name == name);
            if (courseSituation is null)
                throw new CourseSituationNotExistsException();
            else
            {
                return courseSituation;
            }
        }

        public List<CourseSituation> GetOnlyActives()
        {
            return _context.CourseSituations.Where(c => c.Inactive == false).ToList();
        }

        public int Save(CourseSituation courseSituation)
        {
            int courseSituationID = 0;
            var courseSituationContext = _context.CourseSituations.FirstOrDefault(s => s.Name == courseSituation.Name);

            if (courseSituationContext.Name == null || String.IsNullOrEmpty(courseSituationContext.Name))
                throw new NameRequiredException();
            else
            {
                if (courseSituationContext is null)
                {
                    _context.CourseSituations.Add(courseSituation);
                    _context.SaveChanges();

                    courseSituationID = courseSituation.ID;
                }   
                else
                {
                    courseSituationContext.Name = courseSituation.Name;
                    courseSituationContext.Inactive = courseSituation.Inactive;

                    _context.SaveChanges();

                    courseSituationID = courseSituationContext.ID;

                }
            }

            return courseSituationID;
        }
    }
}
