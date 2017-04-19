using BAISTGolfCourse.BLL.ServiceInterfaces;
using BAISTGolfCourse.ViewModels.InputModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BAISTGolfCourse.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public AdminController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            if (Request.Cookies["IsAdministrator"] != null)
            {
                if (User.Identity.IsAuthenticated)
                {
                    var id = int.Parse(User.Identity.Name);

                    return RedirectToAction("Dashboard", "Admin",
                                    new { id = id });
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();

            //Remove IsAdministrator cookie
            if (Request.Cookies["isAdministrator"] != null)
            {
                var adminCookie = Request.Cookies["isAdministrator"];
                adminCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(adminCookie);
            }

            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public ActionResult Login(LoginInputModel inputModel)
        {

            if (ModelState.IsValid)
            {
                var user = _employeeService.GetUserByEmail(inputModel.EmailAddress);

                if (user != null)
                {
                    var validatedUser = _employeeService.ValidateUser(inputModel.Password, user);

                    if (validatedUser != null)
                    {
                        //Create IsAdmin Cookie
                        var cookie = new HttpCookie("IsAdministrator");
                        cookie.Value = "true";
                        cookie.Expires = DateTime.Now.AddDays(5);

                        Response.Cookies.Add(cookie);

                        FormsAuthentication.SetAuthCookie(validatedUser.ID.ToString(),
                                inputModel.RememberMe);

                        return RedirectToAction("Dashboard", "Admin", new
                        { id = validatedUser.ID });
                    }

                }
            }
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            return Json("Something went wrong!", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Dashboard(int id)
        {
            var employee = _employeeService.GetUserByID(id);
            return View(employee);
        }
    }
}