using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using DAL.Repositories;
using BLL.Domains;

namespace WebApplicationBookStore3.Controllers
{
    public class BookController : Controller
    {
       
        public readonly UserBookDomain userBookDomain = new UserBookDomain();
        public readonly BookDomain bookDomain = new BookDomain();
        public readonly CategoryDomain categoryDomain = new CategoryDomain();
        public readonly AuthorDomain authorDomain = new AuthorDomain();

        // GET: Book
        public ActionResult Index() // Include Because drop down list
        {
            var books = bookDomain.GetAllBooks();
            return View(books);
        }

        public ActionResult CreateBook()
        {
            List<Category> categories = categoryDomain.GetAllCategories();//drop down list
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            List<Author> authors = authorDomain.GetAllAuthors();
            ViewBag.Author = new SelectList(authors, "Id", "Name"); //drop down list

            return View();
        }

        public ActionResult AddBook(Book book,
                HttpPostedFileBase BookCover,//Because img
                HttpPostedFileBase UploadBook)//Because img
        {
            if (ModelState.IsValid)
            {
                // upload book cover
                var pathCover = Path.Combine(Server.MapPath("~/Uploads"), BookCover.FileName); //System.IO
                BookCover.SaveAs(pathCover);
                book.BookCover = "/Uploads/" + BookCover.FileName;

                // upload book                              
                var pathFile = Path.Combine(Server.MapPath("~/Uploads"), UploadBook.FileName); //System.IO
                UploadBook.SaveAs(pathFile);
                book.UploadBook = "/Uploads/" + UploadBook.FileName;

                bookDomain.Insert(book);

                return RedirectToAction("Index", "book");
            }

            List<Category> categories = categoryDomain.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            List<Author> authors = authorDomain.GetAllAuthors();
            ViewBag.Author = new SelectList(authors, "Id", "Name");

            return View("CreateBook", book);
        }

        public ActionResult EditBook(int id)
        {
            var book = bookDomain.Edit(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            List<Category> categories = categoryDomain.GetAllCategories(); ;
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            List<Author> authors = authorDomain.GetAllAuthors();
            ViewBag.Author = new SelectList(authors, "Id", "Name");

            return View(book);
        }

        public ActionResult ModifyBook(Book book,
                            HttpPostedFileBase BookCover,
                            HttpPostedFileBase UploadBook)
        {
            if (ModelState.IsValid)
            {
                if (BookCover != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Uploads"), BookCover.FileName);
                    BookCover.SaveAs(path);
                    book.BookCover = "/Uploads/" + BookCover.FileName;
                }

                if (UploadBook != null)
                {
                    var pathFile = Path.Combine(Server.MapPath("~/UploadBook"), UploadBook.FileName);
                    UploadBook.SaveAs(pathFile);
                    book.UploadBook = "/UploadBook/" + UploadBook.FileName;
                }

                bookDomain.Modify(book);

                return RedirectToAction("Index", "Book");
            }


            List<Category> categories = categoryDomain.GetAllCategories();
            ViewBag.Categories = new SelectList(categories, "Id", "Name");

            List<Author> authors = authorDomain.GetAllAuthors();
            ViewBag.Author = new SelectList(authors, "Id", "Name");

            return View("EditBook", book);
        }

        public ActionResult DeleteBook(int id)
        {
            var book = bookDomain.Delete(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return View("DeleteBook", book);
        }

        public ActionResult ConfirmDeleteBook(int id)
        {
            var book = bookDomain.ConfirmDelete(id);

            if (book == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult SearchResult(Book book)
        {
            var foundBooks = bookDomain.SearchResult(book);
            if (foundBooks != null)
            {
                ViewBag.IsSearch = true;
                ViewBag.FoundBooks = foundBooks;
            }

            return View("Search", book);
        }

        public ActionResult LikeBook(int bookId, int userId)
        {
            UserBook userBooks = new UserBook()
            {
                BookId = bookId,
                UserId = userId
            };

            
            userBookDomain.LikeBook(userBooks);
            return RedirectToAction("BookDetails", "PublicCategory", new { id = bookId });
        }

        public ActionResult DisLikeBook(int bookId, int userId)
        {
            userBookDomain.DisLikeBook(bookId, userId);
            return RedirectToAction("BookDetails", "PublicCategory", new { id = bookId });
        }

        public ActionResult DownloadNumber(int id)
        {
            bookDomain.DownloadNumber(id);

            var book = bookDomain.GetBookById(id);
            var filePath = book.UploadBook;
            byte[] fileBytes = GetFile(filePath);

            return File(fileBytes, "application/pdf", filePath);
        }

        private byte[] GetFile(string filePath)
        {
            string fullName = Server.MapPath("~" + filePath);

            using (FileStream fs = System.IO.File.OpenRead(filePath))
            {
                byte[] data = new byte[fs.Length];
                int br = fs.Read(data, 0, data.Length);
                if (br != fs.Length)
                    throw new System.IO.IOException(filePath);

                return data;
            }
        }
    }
}