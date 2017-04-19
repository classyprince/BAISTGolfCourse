using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApplicantService _applicantService;
        private readonly IMemberService _memberService;

        public HomeController(IApplicantService applicantService,
            IMemberService memberService)
        {
            _applicantService = applicantService;
            _memberService = memberService;
        }
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
            else
            {
                if (User.Identity.IsAuthenticated)
                {
                    var user = _applicantService.GetUserByEmail(User.Identity.Name);

                    if (user.Status == Common.Enums.ApplicantStatus.Approved)
                    {
                        var memberVieModel = _memberService.GetMemberByEmail(user.EmailAddress);

                        return RedirectToAction("Account", "Member",
                                    new { id = memberVieModel.MembershipID });
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Applicant",
                                    new { id = user.ID });
                    }
                }
                return View();
            }
            return View();
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}