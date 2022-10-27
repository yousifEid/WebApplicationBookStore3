using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository
    {
        private BookStoreDbContext db = new BookStoreDbContext();

        public List<Book> GetAllBooks()
        {
            List<Book> books = db.Books.Include(e => e.Category).Include(e => e.Author).ToList();
            return (books);
        }

        public Book GetBookById(int id)
        {
            Book book = db.Books.Where(e => e.Id == id)
                               .Include(e => e.Category)
                               .Include(e => e.Author)
                               .FirstOrDefault();

            return book;
        }
        public Book Insert(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
            return book;
        }

        public Book Edit(int id)
        {
            var book = db.Books.Find(id);
            db.SaveChanges();
            return book;
        }

        public Book Modify(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return book;
        }

        public Book Delete(int id)
        {
            var book = db.Books.Find(id);
            return book;
        }

        public Book ConfirmDelete(int id)
        {
            var book = db.Books.Find(id);
            db.Entry(book).State = EntityState.Deleted;
            db.Books.Remove(book);
            db.SaveChanges();
            return book;
        }

        public bool IsLiked(int bookId, int userId)
        {
            bool isLiked = db.UserBooks.Any(e => e.UserId == userId
                                              && e.BookId == bookId);

            return isLiked;
        }

        public List<Book> GetCategoryBooks(int id)
        {
            var books = db.Books.Where(e => e.CategoryId == id)
                                .Include(e => e.Category)
                                .Include(e => e.Author)
                                .ToList();
            return books;
        }

        public List<Book> GetAuthorBooks(int id)
        {
            var books = db.Books.Where(e => e.AuthorId == id)
                                  .Include(e => e.Category)
                                  .Include(e => e.Author)
                                  .ToList();
            return books;
        }

        public List<Book> SearchResult(Book book)
        {
            List<Book> foundBooks = db.Books.Where(b => b.Name.Contains(book.Name))
                                     .Include(e => e.Category)
                                     .Include(e => e.Author)
                                     .ToList();
            return foundBooks;
        }

        public Book DownloadNumber(int id)
        {
            Book book = db.Books.Find(id);
            db.Entry(book).State = EntityState.Modified;

            book.DownloadNumber += 1;
            
            db.SaveChanges();
            return book;
        }

        public Book ReadingNumber(int id)
        {
            Book book = db.Books.Find(id);
            db.Entry(book).State = EntityState.Modified;
            int number = book.ReadingNumber;
            book.ReadingNumber = number + 1;
            db.SaveChanges();
            return book;
        }

    }
}
