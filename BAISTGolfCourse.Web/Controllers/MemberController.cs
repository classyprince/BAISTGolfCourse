using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BAISTGolfCourse.Web.Controllers
{
    [Authorize]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        public ActionResult Account(string id)
        {
            var memberViewModel = _memberService.GetMemberByMembershipID(id);

            var rememberMe = Session["rememberMe"] as bool?;
            if (rememberMe != null)
                FormsAuthentication.SetAuthCookie(memberViewModel.EmailAddress, rememberMe.Value);
            else
                FormsAuthentication.SetAuthCookie(memberViewModel.EmailAddress, false);
            return View(memberViewModel);
        }
    }
}