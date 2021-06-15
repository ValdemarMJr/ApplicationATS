using ATS.CoreAPI.Exceptions;
using ATS.CoreAPI.Model.Context;
using ATS.CoreAPI.Model.DTO;
using ATS.CoreAPI.Model.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly SQLContext _context;
       
        public UserRepository(SQLContext context)
        {
            _context = context;  
        }

        public User ValidateCredentials(UserDTO user)
        {
            var userContext = _context.Users.FirstOrDefault(u => u.UserName == user.UserName);
            if (userContext is null)
                throw new UserNotExistsException();

            if (!userContext.Inactive)
            {
               
                if (string.IsNullOrEmpty(userContext.Password))
                    throw new UserPasswordNotSetException(userContext);
                if (userContext.Password.Equals(user.Password))
                    return userContext;
                else
                    return null;
                
            }
            throw new InactiveUserException();
        }

        public User ValidateCredentials(string userName)
        {
            return _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
        }

        public bool RevokeToken(string userName)
        {
            var user = _context.Users.SingleOrDefault(u => u.UserName.Equals(userName));
            if (user is null) return false;
            user.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        public User RefreshUserInfo(User user)
        {
            if (!Exists(user.ID)) return null;
            var result = _context.Users.SingleOrDefault(u => u.ID.Equals(user.ID));
            if (result != null)
            {
                _context.Entry(result).CurrentValues.SetValues(user);
                _context.SaveChanges();
            }
            return result;
        }

        public bool Exists(int id)
        {
            return _context.Users.Any(p => p.ID.Equals(id));
        }

        public User Get(int id)
        {
            return _context.Users.FirstOrDefault(u => u.ID.Equals(id));
        }
        public User GetByCPF(string cpf)
        {
            return _context.Users.FirstOrDefault(u => u.CPF.Replace(".", "").Replace("-", "").Equals(cpf.Replace(".", "").Replace("-", "")));
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email.ToUpper().Equals(email.ToUpper()));
        }

        public User GetByUserName(string userName)
        {
            return _context.Users.FirstOrDefault(u => u.UserName.ToUpper().Equals(userName.ToUpper()));
        }

        public int Save(User user)
        {
            int userID = 0;
            var userContext = _context.Users.FirstOrDefault(u => u.CPF == user.CPF);

            if (user.Name == null || String.IsNullOrEmpty(user.Name))
                throw new NameRequiredException();
            else if (user.UserName == null || String.IsNullOrEmpty(user.UserName))
                throw new UserNameRequiredException();
            else if (user.Password == null || String.IsNullOrEmpty(user.Password))
                throw new PasswordRequiredException();
            else if (user.Email == null || String.IsNullOrEmpty(user.Email))
                throw new EmailRequiredException();
            else if (user.CPF == null || String.IsNullOrEmpty(user.CPF))
                throw new CPFRequiredException();
            else
            {
                if (userContext is null)
                {
                   _context.Users.Add(user);
                    _context.SaveChanges();
                    userID = user.ID;
                }
                else
                {
                    userContext.Name = user.Name;
                    userContext.Email = user.Email;
                    userContext.Inactive = user.Inactive;
                    userContext.Password = user.Password;
                    _context.SaveChanges();

                    userID = userContext.ID;

                }
            }

            return userID;
        }

        public bool Delete(int id)
        {
            var userContext = _context.Users.FirstOrDefault(u => u.ID == id);
            if (userContext is null)
                throw new UserNotExistsException();
            else
            {
                List<CandidateAcademicEducation> academicEducation = _context.CandidateAcademicsEducation.Where(a => a.CandidateID == id).ToList();

                foreach (var item in academicEducation)
                    _context.CandidateAcademicsEducation.Remove(item);

                List<CandidateContact> contacts = _context.CandidateContacts.Where(a => a.CandidateID == id).ToList();

                foreach (var item in contacts)
                    _context.CandidateContacts.Remove(item);


                List<CandidateExperience> experiences = _context.CandidateExperiences.Where(a => a.CandidateID == id).ToList();

                foreach (var item in experiences)
                    _context.CandidateExperiences.Remove(item);

                List<CandidateImprovementCourse> courses = _context.CandidateImprovementCourses.Where(a => a.CandidateID == id).ToList();

                foreach (var item in courses)
                    _context.CandidateImprovementCourses.Remove(item);

                List<CandidatePersonalReference> references = _context.CandidatePersonalReferences.Where(a => a.CandidateID == id).ToList();

                foreach (var item in references)
                    _context.CandidatePersonalReferences.Remove(item);

                List<CandidateRole> roles = _context.CandidateRoles.Where(a => a.CandidateID == id).ToList();

                foreach (var item in roles)
                    _context.CandidateRoles.Remove(item);

                Candidate candidate = _context.Candidates.Where(c => c.ID == id).FirstOrDefault();
                Address address = _context.Adresses.Where(a => a.ID == candidate.AddressID).FirstOrDefault();
                _context.Adresses.Remove(address);
                _context.Candidates.Remove(candidate);

                _context.Users.Remove(userContext);
                _context.SaveChanges();
                return true;
            }
        }

        public bool RegisteredUser(string cpf)
        {
            var userContext = _context.Users.FirstOrDefault(u => u.CPF == cpf);
            if (userContext is null)
                return false;
            else
                return true;
        }

        public bool UpdatePassword(int id, string password)
        {
            var userContext = _context.Users.FirstOrDefault(u => u.CPF == password);
            if (userContext is null) 
                throw new UserNotExistsException();
            else
            {
                userContext.Password = password;
                _context.SaveChanges();
                return true;
            }
        }
    }
}
