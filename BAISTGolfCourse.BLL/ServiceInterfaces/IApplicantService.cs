using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.ViewModels.InputModels.Applicant;
using BAISTGolfCourse.ViewModels.ViewModels.Applicant;
using System.Collections.Generic;

namespace BAISTGolfCourse.BLL.ServiceInterfaces
{
    public interface IApplicantService
    {
        CreateInputModel Create();
        ApplicantViewModel CreateApplicant(CreateInputModel inputModel);
        ApplicantViewModel GetUserByEmail(string EmailAddress);
        ApplicantViewModel GetUserByID(int id);
        ApplicantViewModel ValidateUser(string passwordProvided, ApplicantViewModel applicant);
        ApplicantRequestViewModel GetUserDetailByID(int id);
        ApplicantRequestViewModel GetUserDetailChangeStatusByID(int id);
        void AcceptRejectApplicant(int memberID, int applicantID, int status);
        List<ApplicantReportViewModel> GetAllApplicants();
        List<ApplicantReportViewModel> GetAllApplicantsApproved();
        List<ApplicantReportViewModel> GetAllApplicantsNotApproved();
    }
}
