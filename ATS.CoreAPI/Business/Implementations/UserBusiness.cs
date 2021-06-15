using ATS.CoreAPI.Model.Entitys;
using ATS.CoreAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.CoreAPI.Bussiness.Implementations
{
    public class UserBussines : IUserBusiness
    {
        private readonly IUserRepository _repository;

        public UserBussines(IUserRepository repository)
        {
            _repository = repository;
        }

        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }

        public User Get(int id)
        {
            return _repository.Get(id);
        }

        public User GetByCPF(string cpf)
        {
            return _repository.GetByCPF(cpf);
        }
        public User GetByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }

        public User GetByUserName(string userName)
        {
            return _repository.GetByUserName(userName);
        }

        public int Save(User user)
        {
            return _repository.Save(user);
        }

        public bool UpdatePassword(int id, string password)
        {
            return _repository.UpdatePassword(id, password);
        }
    }
}
