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

    public class UserBus
    {
        private readonly UserDAO _userRepository;

        public UserBus(UserDAO userRepository)
        {
            _userRepository = userRepository;
        }

		public List<User> GetListUser()
		{
            return _userRepository.GetAll().ToList();
		}

		public User GetUser(int Id)
        {
            return _userRepository.GetById(Id);
        }

        public async Task Update(User user)
        {
            var userCheck = _userRepository.GetById(user.Id);
            if (userCheck != null)
            {
                userCheck.Name = user.Name;
                _userRepository.Update(userCheck);
                await _userRepository.SaveChangesAsync();
            }
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


        public bool Delete(int Id)
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
