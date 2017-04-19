using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    [Authorize]
    public class LiveChatController : Controller
    {
        private readonly IMemberService _memberService;

        public LiveChatController(IMemberService memberService)
        {
            _memberService = memberService;
        }
        public ActionResult Index()
        {
            var member = _memberService.GetMemberByEmail(User.Identity.Name);
            return View(member);
        }

    }
}