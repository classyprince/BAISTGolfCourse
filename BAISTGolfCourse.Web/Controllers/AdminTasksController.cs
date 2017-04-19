using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BAISTGolfCourse.Web.Controllers
{
    [Authorize]
    public class AdminTasksController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IApplicantService _applicantService;

        public AdminTasksController(IEmployeeService employeeService, 
            IApplicantService applicantService)
        {
            _employeeService = employeeService;
            _applicantService = applicantService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ApplicantRequests()
        {
            var applicants = _employeeService.GetAllNewApplicants();
            return View(applicants);
        }

        [HttpGet]
        public ActionResult Application(int id)
        {
            var applicant = _applicantService.GetUserDetailChangeStatusByID(id);
            return View(applicant);
        }

        [HttpGet]
        public ActionResult MakeDecision(int id, string option)
        {
            var response = _employeeService.MakeDecision(option, id);

            if (response)                
                return Json("You have successfuly approved the applicant", JsonRequestBehavior.AllowGet);
            else
                return Json("You have successfuly rejected the applicant", JsonRequestBehavior.AllowGet);
        }

    }
}
