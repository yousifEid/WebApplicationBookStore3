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
    public class AuthorController : Controller
    {
       
        public readonly AuthorDomain authorDomain = new AuthorDomain();
        // GET: Author
        public ActionResult Index()
        {
            var authors = authorDomain.GetAllAuthors();
            return View(authors);
        }

        public ActionResult CreateAuthor()
        {
            return View();
        }

        public ActionResult AddAuthor(Author author, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var path = Path.Combine(Server.MapPath("~/Uploads"), Image.FileName);
                Image.SaveAs(path);
                author.Image = "/Uploads/" + Image.FileName;

                authorDomain.Insert(author);

                return RedirectToAction("Index", "Author");
            }

            return View("CreateAuthor", author);
        }

        public ActionResult EditAuthor(int id)
        {
            var author = authorDomain.Edit(id);

            return View(author);
        }

        public ActionResult ModifyAuthor(Author author, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    var path = Path.Combine(Server.MapPath("~/Uploads"), Image.FileName);
                    Image.SaveAs(path);
                    author.Image = "/Uploads/" + Image.FileName;
                }

                authorDomain.Modify(author);

                return RedirectToAction("Index", "Author");
            }

            return View("Index", author);
        }

        public ActionResult DeleteAuthor(int id)
        {
            var author = authorDomain.Delete(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            return View("DeleteAuthor", author);
        }

        public ActionResult ConfirmDeleteAuthor(int id)
        {
            var author = authorDomain.ConfirmDelete(id);

            if (author == null)
            {
                return HttpNotFound();
            }

            return RedirectToAction("Index");
        }
    }
}