using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.ViewModels.InputModels.Applicant;
using BAISTGolfCourse.ViewModels.ViewModels.Applicant;
using BAISTGolfCourse.ViewModels.ViewModels.Employee;
using BAISTGolfCourse.ViewModels.ViewModels.Member;
using System.Collections.Generic;

namespace BAISTGolfCourse.BLL.ServiceInterfaces
{
    public interface IEmployeeService
    {
        //CreateInputModel Create();
        //ApplicantViewModel CreateApplicant(CreateInputModel inputModel);
        EmployeeViewModel GetUserByEmail(string EmailAddress);
        EmployeeViewModel GetUserByID(int id);
        EmployeeViewModel ValidateUser(string passwordProvided, EmployeeViewModel applicant);
        List<ApplicantRequestViewModel> GetAllNewApplicants();
        bool MakeDecision(string action, int id);
    }
}
