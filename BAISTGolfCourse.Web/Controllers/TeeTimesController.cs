using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    [Authorize]
    public class TeeTimesController : Controller
    {
        private readonly ITeeTimeService _teeTimeService;
        public TeeTimesController(ITeeTimeService teeTimeService)
        {
            _teeTimeService = teeTimeService;
        }

        public ActionResult GetWithMembers(int id)
        {
            var teeTime = _teeTimeService.GetWithMembers(id);

            return PartialView(teeTime);
        }
    }
}