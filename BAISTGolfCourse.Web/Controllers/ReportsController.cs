using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    public class ReportsController : Controller
    {
        private readonly IPlayerScoreService _playerScoreService;
        private readonly IApplicantService _applicantService;
        public ReportsController(IPlayerScoreService playerScoreService,
            IApplicantService applicantService)
        {
            _playerScoreService = playerScoreService;
            _applicantService = applicantService;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Scores()
        {
            var scores = _playerScoreService.GetAllUserScores();
            return PartialView(scores);
        }

        public ActionResult ScoresByMale()
        {
            var scores = _playerScoreService.GetAllUserScoresMale();
            return PartialView("Scores", scores);
        }

        public ActionResult ScoresByFemale()
        {
            var scores = _playerScoreService.GetAllUserScoresFemale();
            return PartialView("Scores", scores);
        }

        public ActionResult Applicants()
        {
            var users = _applicantService.GetAllApplicants();
            return PartialView(users);
        }

        public ActionResult ApplicantsApproved()
        {
            var users = _applicantService.GetAllApplicantsApproved();
            return PartialView("Applicants", users);
        }

        public ActionResult ApplicantsNotApproved()
        {
            var users = _applicantService.GetAllApplicantsNotApproved();
            return PartialView("Applicants", users);
        }
    }

    
}