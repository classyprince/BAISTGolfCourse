using BAISTGolfCourse.BLL.ServiceInterfaces;
using BAISTGolfCourse.ViewModels.InputModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    [Authorize]
    public class ReservationsController : Controller
    {
        private readonly IReservationService _reservationService;
        private readonly ITeeTimeService _teeTimeService;
        public ReservationsController(IReservationService reservationService,
            ITeeTimeService teeTimeService)
        {
            _reservationService = reservationService;
            _teeTimeService = teeTimeService;
        }
        // GET: Reservation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ReservationCreateInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var create = _reservationService.CreateReservation(inputModel, User.Identity.Name);
                if (create)
                    return Json("OK", JsonRequestBehavior.AllowGet);
                else
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }     
            else
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        public ActionResult FindTeeTimes(TeeTimeFinderModel teeTimeFinder)
        {
            var teeTimeList = _reservationService.FindTeeTimes(teeTimeFinder);
            return PartialView(teeTimeList);
        }

        [HttpPost]
        public ActionResult AddMembers(string memberID, int teeTimeID)
        {
            var member = _reservationService.AddMemberToReservation(memberID, teeTimeID,
                User.Identity.Name);

            return Json(member, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult GetWithMembers()
        {
            return PartialView();
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var teeTimeWithReservations = _teeTimeService.GetWithMembers(id);
            return View(teeTimeWithReservations);
        }

        [HttpGet]
        public ActionResult GetList()
        {
            var reservations = _reservationService.GetReservations(User.Identity.Name);

            var reservationsCalendar = reservations.Select(x => new
            {
                id = x.TeeTimeID,
                title =
                "Reservation For " + x.MemberFullName,
                start = x.TeeTimeStartDate.ToString("s"),
                end = x.TeeTimeStartDate.ToString("s"),
                allDay = false
            });
            return Json(reservationsCalendar, JsonRequestBehavior.AllowGet);
        }
    }
}