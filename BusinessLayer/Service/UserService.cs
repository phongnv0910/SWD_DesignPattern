using Data_Access_Layer.Repository;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Service
{

    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User GetUser(int Id)
        {
            return _userRepository.GetById(Id);
        }

        public bool UpdateUser(int Id)
        {
            var user = _userRepository.GetById(Id);
            if (user != null)
            {
                _userRepository.Delete(user);
                return true;
            }
            return false;
        }
    }
}
