using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Domains;
using DAL.Models;
using DAL.Repositories;
using WebApplicationBookStore3.Models;

namespace WebApplicationBookStore3.Controllers
{
    public class AccountController : Controller
    {
       
        public readonly UserDomain userDomain = new UserDomain();

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult AddRegister(User user)
        {
            if (ModelState.IsValid)
            {
                bool isExist = userDomain.IsExist(user);
                if (!isExist)
                {
                    userDomain.Insert(user);
                    ViewBag.Message = "تم التسجيل بنجاح";

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Name or Email already exists");
                }
            }

            return View("Register", user);
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult AddLogin(LogInViewModel logIn)
        {
            if (ModelState.IsValid)
            {
                bool isExist = userDomain.ValidateLogin(logIn.Mail, logIn.Password);

                if (isExist)
                {
                    User userInfo = userDomain.GetByLogin(logIn.Mail, logIn.Password);

                    ViewBag.Message = "تم تسجيل الدخول بنجاح";

                    Session["IsLoggedIn"] = "true";
                    Session["LoggedInUserId"] = userInfo.Id;
                    Session["LoggedInUserName"] = userInfo.Name;
                    Session["LoggedInUserMail"] = userInfo.Mail;

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect email or password");
                }

            }
            else
            {
                ModelState.AddModelError("", "يوجد خطا في البيانات المدخلة ");
            }

            return View("Login", logIn);
        }

        public ActionResult Logout()
        {
            Session["IsLoggedIn"] = "false";

            return RedirectToAction("Index", "Home");
        }
    }
}