using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserBookRepository
    {
        public BookStoreDbContext db = new BookStoreDbContext();

        public UserBook LikeBook(UserBook userBook)
        {
            db.UserBooks.Add(userBook);
            db.SaveChanges();
            return userBook;
        }

        public UserBook DisLikeBook(int bookId, int userId)
        {
            UserBook userBooks = db.UserBooks.Where(e => e.BookId == bookId
                                                       && e.UserId == userId)
                                                       .FirstOrDefault();

            db.UserBooks.Remove(userBooks);
            db.SaveChanges();
            return userBooks;
        }
    }
}
