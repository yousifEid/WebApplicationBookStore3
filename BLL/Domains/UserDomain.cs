using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class UserDomain
    {
        public UserRepository userRepository = new UserRepository();

        public User Insert(User user)
        {
            return userRepository.Insert(user);
        }

        public bool IsExist(User user)
        {
            return userRepository.IsExist(user);
        }

        public bool ValidateLogin(string mail, string password)
        {
            return userRepository.ValidateLogin(mail, password);
        }

        public User GetByLogin(string mail, string password)
        {
            return userRepository.GetByLogin(mail, password);
        }

       
    }
}
