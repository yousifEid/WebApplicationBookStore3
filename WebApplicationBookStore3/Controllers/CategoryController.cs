using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Models;
using System.Data.Entity;
using DAL.Repositories;
using BLL.Domains;

namespace WebApplicationBookStore3.Controllers
{
    public class CategoryController : Controller
    {
        public readonly CategoryDomain categoryDomain = new CategoryDomain();
        // GET: Category
        public ActionResult Index()
        {
            var categories=categoryDomain.GetAllCategories();
            return View(categories);
        }

        public ActionResult CreateCategory()
        {
            return View();
        }

        public ActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryDomain.Insert(category);
                

                return RedirectToAction("Index", "Category");
            }

            return View("CreateCategory", category);
        }

        public ActionResult EditCategory(int id )
        {
            var category = categoryDomain.Edit(id);
            return View(category);
        }

        public ActionResult ModifyCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                categoryDomain.Modify(category);
               

                return RedirectToAction("Index", "Category");
            }

            return View("Index", category);
        }

        public ActionResult DeleteCategory(int id)
        {
            var category= categoryDomain.Delete(id);
            if (category == null)
            {
                return HttpNotFound();
            }

            return View("DeleteCategory", category);
        }

        public ActionResult ConfirmDeleteCategory(int id)
        {
            var category= categoryDomain.ConfirmDelete(id);
            if (category == null)
            {
                return HttpNotFound();
            }
           
            return RedirectToAction("Index");
        }
    }
}