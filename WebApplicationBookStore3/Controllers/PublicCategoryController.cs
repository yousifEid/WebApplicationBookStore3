using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using DAL.Repositories;
using BLL.Domains;

namespace WebApplicationBookStore3.Controllers
{
    public class PublicCategoryController : Controller
    {
        public readonly BookDomain bookDomain = new BookDomain();
        public readonly CategoryDomain categoryDomain = new CategoryDomain();

       // GET: PublicCategory
       public ActionResult Index()
        {
            var categories = categoryDomain.GetAllCategories();
            return View(categories);
        }

        public ActionResult BookDetails(int id)
        {
            int userId = Convert.ToInt32(Session["LoggedInUserId"]);

            var book = bookDomain.GetBookById(id);

            var isLiked = bookDomain.IsLiked(id, userId);

            ViewBag.BookId = book.Id;
            ViewBag.UserId = userId;

            ViewBag.IsLiked = isLiked;

            bookDomain.ReadingNumber(id);

            return View(book);
        }

        public ActionResult CategoryBook(int id)
        {
            var books = bookDomain.GetCategoryBooks(id);

            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }

        public ActionResult AuthorBook(int id)
        {
            var books = bookDomain.GetAuthorBooks(id);

            if (books == null)
            {
                return HttpNotFound();
            }
            return View(books);
        }
    }
}