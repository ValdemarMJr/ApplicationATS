using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository.Implementation
{
    public class GenderRepository : IGenderRepository
    {
        private readonly SQLContext _context;

        public GenderRepository(SQLContext context)
        {
            _context = context;
        }
        public bool Delete(int id)
        {
            var gender = _context.Genders.FirstOrDefault(s => s.ID == id);
            if (gender is null)
                throw new GenderNotExistsException();
            else
            {
                _context.Genders.Remove(gender);
                _context.SaveChanges();
                return true;
            }
        }

        public Gender Get(int id)
        {
            var gender = _context.Genders.FirstOrDefault(s => s.ID == id);
            if (gender is null)
                throw new GenderNotExistsException();
            else
            {
                return gender;
            }
        }

        public List<Gender> GetAll()
        {
            return _context.Genders.ToList();
        }

        public Gender GetByName(string name)
        {
            var gender = _context.Genders.FirstOrDefault(s => s.Name == name);
            if (gender is null)
                throw new GenderNotExistsException();
            else
            {
                return gender;
            }
        }

        public List<Gender> GetOnlyActives()
        {
            return _context.Genders.Where(s => s.Inactive == false).ToList();
        }

        public int Save(Gender gender)
        {
            int genderID = 0;
            var genderContext = _context.Genders.FirstOrDefault(g => g.Name == gender.Name);

            if (gender.Name == null || String.IsNullOrEmpty(gender.Name))
                throw new NameRequiredException();
            else
            {
                if (genderContext is null)
                {
                    _context.Genders.Add(gender);
                    _context.SaveChanges();

                    genderID = gender.ID;
                }
                else
                {
                    genderContext.Name = gender.Name;
                    genderContext.Inactive = gender.Inactive;

                    _context.SaveChanges();

                    genderID = genderContext.ID;

                }
            }

            return genderID;
        }
    }
}
