using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepository
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        // CRUD Operations

        public User Insert(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }


        public bool IsExist(User user)
        {
            var isExist = db.Users.Any(e => e.Name == user.Name ||
                                            e.Mail == user.Mail);

            return isExist;
        }

        public bool ValidateLogin(string mail, string password)
        {
            bool isExist = db.Users.Any(e => e.Password == password &&
                                                 e.Mail == mail);

            return isExist;
        }

        public User GetByLogin(string mail, string password)
        {
            var user = db.Users.Where(e => e.Password == password &&
                                                 e.Mail == mail).FirstOrDefault();

            return user;
        }

        public List<User> GetAllUsers()
        {
            var users = db.Users.ToList();

            return users;
        }

    }
}
