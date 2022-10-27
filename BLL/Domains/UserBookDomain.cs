using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class UserBookDomain
    {
        public UserBookRepository userBookRepository = new UserBookRepository();

        public UserBook LikeBook(UserBook userBook)
        {
            return userBookRepository.LikeBook(userBook);
        }

        public UserBook DisLikeBook(int bookId, int userId)
        {
            return userBookRepository.DisLikeBook(bookId, userId);
        }
    }
}
