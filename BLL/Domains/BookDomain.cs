using DAL.Models;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Domains
{
    public class BookDomain
    {
        public BookRepository bookRepository = new BookRepository();

        public List<Book> GetAllBooks()
        {
            return bookRepository.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return bookRepository.GetBookById(id);
        }

        public Book Insert(Book book)
        {
            return bookRepository.Insert(book);
        }

        public Book Edit(int id)
        {
            return bookRepository.Edit(id);
        }

        public Book Modify(Book book)
        {
            return bookRepository.Modify(book);
        }

        public Book Delete(int id)
        {
            return bookRepository.Delete(id);
        }

        public Book ConfirmDelete(int id)
        {
            return bookRepository.ConfirmDelete(id);
        }

        public List<Book> SearchResult(Book book)
        {
            return bookRepository.SearchResult(book);
        }


        public bool IsLiked(int bookId, int userId)
        {
            return bookRepository.IsLiked(bookId, userId);
        }

        public List<Book> GetCategoryBooks(int id)
        {
            return bookRepository.GetCategoryBooks(id);
        }

        public List<Book> GetAuthorBooks(int id)
        {
            return bookRepository.GetAuthorBooks(id);
        }

        public Book DownloadNumber(int id)
        {
            return bookRepository.DownloadNumber(id);
        }

        public Book ReadingNumber(int id)
        {
            return bookRepository.ReadingNumber(id);
        }


    }
}
