using BAISTGolfCourse.BLL.ServiceInterfaces;
using BAISTGolfCourse.ViewModels.InputModels.PlayerScore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    [Authorize]
    public class PlayerScoreController : Controller
    {
        private readonly IPlayerScoreService _playerScoreService;
        public PlayerScoreController(IPlayerScoreService playerScoreService)
        {
            _playerScoreService = playerScoreService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EnterMemberScore()
        {
            return View();
        }

        [HttpGet]
        public ActionResult EnterPlayerScore()
        {
            var createInputModel = _playerScoreService.GetInputModel(User.Identity.Name);
            return PartialView(createInputModel);
        }

        [HttpGet]
        public ActionResult EnterPlayerScoreAdmin()
        {
            var createInputModel = _playerScoreService.GetInputModelForAdmin();
            return PartialView(createInputModel);
        }

        [HttpPost]
        public ActionResult EnterPlayerScore(CreateInputModel model)
        {
            if (ModelState.IsValid)
            {
                var response = _playerScoreService.CreatePlayerScore(model, User.Identity.Name);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult EnterPlayerScoreAdmin(CreateInputModelWithMember model)
        {
            if (ModelState.IsValid)
            {
                var response = _playerScoreService.CreatePlayerScore(model);
                return Json(response, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpGet]
        public ActionResult GetPlayerScore()
        {
            var userScore = _playerScoreService.GetWeeklyReport(User.Identity.Name);

            return Json(userScore, JsonRequestBehavior.AllowGet);
        }
    }
}