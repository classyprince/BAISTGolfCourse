using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAISTGolfCourse.ViewModels.InputModels.Applicant;
using BAISTGolfCourse.Common.Helpers;
using BAISTGolfCourse.Repositories.IRepositories;
using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.Common.AutoMapper;
using System.Security.Cryptography;
using System.Web.Security;
using System.IO;
using BAISTGolfCourse.ViewModels.ViewModels.Applicant;
using BAISTGolfCourse.Common.Enums;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class ApplicantService : IApplicantService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IEmailService _emailService;
        private readonly IAutoMapper _autoMapper;
        public ApplicantService(IApplicantRepository applicantRepository, 
            IMemberRepository memberRepository, IEmailService emailService, IAutoMapper autoMapper)
        {
            _applicantRepository = applicantRepository;
            _memberRepository = memberRepository;
            _emailService = emailService;
            _autoMapper = autoMapper;
        }

        public CreateInputModel Create()
        {
            return new CreateInputModel() { Provinces = ProvinceModel.PopulateProvinces() };
        }

        public ApplicantViewModel CreateApplicant(CreateInputModel inputModel)
        {
            var applicantModel = _autoMapper.Map<Applicant>(inputModel);
            applicantModel.PasswordSalt = PasswordEncryptor.CreateSalt(5);

            var hashedPassword = PasswordEncryptor.CreatePasswordHash(applicantModel.Password,
                applicantModel.PasswordSalt);

            applicantModel.Password = hashedPassword;

            //Get the 2 shareholders
            var shareHolderOne = _memberRepository.FindBy(x => x.MembershipID == inputModel.
            ShareHolder1MemberID).SingleOrDefault();

            var shareHolderTwo = _memberRepository.FindBy(x => x.MembershipID == inputModel.
            ShareHolder2MemberID).SingleOrDefault();

            applicantModel.ShareHolder1ID = shareHolderOne.ID;
            applicantModel.ShareHolder2ID = shareHolderTwo.ID;

            //_emailService.SendEmailToSponsors(shareHolderOne.EmailAddress, applicantModel.FirstName + " " + applicantModel.LastName,
            //    applicantModel.FirstName);

            //_emailService.SendEmailToSponsors(shareHolderTwo.EmailAddress, applicantModel.FirstName + " " + applicantModel.LastName,
            //    applicantModel.FirstName);

            applicantModel.RejectionReason = RejectionReason.Other;

            _applicantRepository.Add(applicantModel);
            _applicantRepository.SaveChanges();

            //Send Email To Applicant
            _emailService.SendEmailToApplicant(applicantModel.EmailAddress, applicantModel.FirstName);

            var applicantViewModel = _autoMapper.Map<ApplicantViewModel>(applicantModel);
            return applicantViewModel;
        }

        public ApplicantViewModel GetUserByEmail(string emailAddress)
        {
            var user = _applicantRepository.FindBy(x => x.EmailAddress == emailAddress)
                .SingleOrDefault();
            if (user == null)
                return null;

            var applicantViewModel = _autoMapper.Map<ApplicantViewModel>(user);
            return applicantViewModel;
        }

        public ApplicantViewModel ValidateUser(string passwordProvided, ApplicantViewModel applicant)
        {
            var hashedPassword = PasswordEncryptor.CreatePasswordHash(passwordProvided,
                applicant.PasswordSalt);
            if (hashedPassword.Equals(applicant.Password))
            {
                return applicant;
            }
            else
                return null;
        }

        public ApplicantViewModel GetUserByID(int id)
        {
            var user = _applicantRepository.GetSingle(id);
            if (user == null)
                return null;

            var applicantViewModel = _autoMapper.Map<ApplicantViewModel>(user);
            return applicantViewModel;
        }

        public ApplicantRequestViewModel GetUserDetailByID(int id)
        {
            var user = _applicantRepository.GetWithMembers(id);
            if (user == null)
                return null;

            var applicantViewModel = _autoMapper.Map<ApplicantRequestViewModel>(user);
            return applicantViewModel;
        }

        public void AcceptRejectApplicant(int memberID, int applicantID, int status)
        {
            var applicant = _applicantRepository.GetSingle(applicantID);

            if (status == 0)
            {
                

                if (applicant.ShareHolder1ID == memberID)
                {
                    applicant.HasShareHolderOneConfirmed = false;
                }
                else if (applicant.ShareHolder2ID == memberID)
                    applicant.HasShareHolderTwoConfirmed = false;

                applicant.Status = ApplicantStatus.Rejected;
                applicant.RejectionReason = RejectionReason.ShareHolderRejected;
                _applicantRepository.SaveChanges();
            }

            if (status == 1)
            {
                if (applicant.ShareHolder1ID == memberID)
                {
                    applicant.HasShareHolderOneConfirmed = true;
                }
                else if (applicant.ShareHolder2ID == memberID)
                    applicant.HasShareHolderTwoConfirmed = true;

                _applicantRepository.SaveChanges();
            }

        }

        public ApplicantRequestViewModel GetUserDetailChangeStatusByID(int id)
        {
            var user = _applicantRepository.GetWithMembers(id);
            if (user == null)
                return null;

            user.Status = ApplicantStatus.UnderReview;
            _applicantRepository.SaveChanges();

            var applicantViewModel = _autoMapper.Map<ApplicantRequestViewModel>(user);

            return applicantViewModel;
        }

        public List<ApplicantReportViewModel> GetAllApplicants()
        {
            var applicants = _applicantRepository.GetAll().
                Select(x => new ApplicantReportViewModel
                {
                    EmailAddress = x.EmailAddress,
                    FullName = x.FirstName + " " + x.LastName,
                    Status = (int)x.Status
                }).ToList();

            return applicants;
        }

        public List<ApplicantReportViewModel> GetAllApplicantsApproved()
        {
            var applicants = _applicantRepository.FindBy(x => x.Status == ApplicantStatus.Approved).
                Select(x => new ApplicantReportViewModel
                {
                    EmailAddress = x.EmailAddress,
                    FullName = x.FirstName + " " + x.LastName,
                    Status = (int)x.Status
                }).ToList();

            return applicants;
        }

        public List<ApplicantReportViewModel> GetAllApplicantsNotApproved()
        {
            var applicants = _applicantRepository.FindBy(x => x.Status != ApplicantStatus.Approved).
                Select(x => new ApplicantReportViewModel
                {
                    EmailAddress = x.EmailAddress,
                    FullName = x.FirstName + " " + x.LastName,
                    Status = (int)x.Status
                }).ToList();

            return applicants;
        }
    }
}
