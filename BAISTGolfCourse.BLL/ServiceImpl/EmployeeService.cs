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
using BAISTGolfCourse.ViewModels.ViewModels.Member;
using BAISTGolfCourse.ViewModels.ViewModels.Employee;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IAutoMapper _autoMapper;
        public EmployeeService(IApplicantRepository applicantRepository, 
            IMemberRepository memberRepository,
            IEmployeeRepository employeeRepository, IAutoMapper autoMapper)
        {
            _applicantRepository = applicantRepository;
            _memberRepository = memberRepository;
            _employeeRepository = employeeRepository;
            _autoMapper = autoMapper;
        }

        //public CreateInputModel Create()
        //{
        //    return new CreateInputModel() { Provinces = ProvinceModel.PopulateProvinces() };
        //}

        public void CreateApplicant(CreateInputModel inputModel)
        {
            //var applicantModel = _autoMapper.Map<Applicant>(inputModel);
            //applicantModel.PasswordSalt = PasswordEncryptor.CreateSalt(5);

            //var hashedPassword = PasswordEncryptor.CreatePasswordHash(applicantModel.Password,
            //    applicantModel.PasswordSalt);

            //applicantModel.Password = hashedPassword;

            ////Get the 2 shareholders
            //var shareHolderOne = _memberRepository.FindBy(x => x.MembershipID == inputModel.
            //ShareHolder1MemberID).SingleOrDefault();

            //var shareHolderTwo = _memberRepository.FindBy(x => x.MembershipID == inputModel.
            //ShareHolder2MemberID).SingleOrDefault();

            //applicantModel.ShareHolder1ID = shareHolderOne.ID;
            //applicantModel.ShareHolder2ID = shareHolderTwo.ID;

            //_applicantRepository.Add(applicantModel);
            //_applicantRepository.SaveChanges();

            //var applicantViewModel = _autoMapper.Map<ApplicantViewModel>(applicantModel);
            //return applicantViewModel;
        }

        public EmployeeViewModel GetUserByEmail(string emailAddress)
        {
            var user = _employeeRepository.FindBy(x => x.EmailAddress == emailAddress)
                .SingleOrDefault();
            if (user == null)
                return null;

            var employeeViewModel = _autoMapper.Map<EmployeeViewModel>(user);
            return employeeViewModel;
        }

        public EmployeeViewModel ValidateUser(string passwordProvided, EmployeeViewModel employee)
        {
            var hashedPassword = PasswordEncryptor.CreatePasswordHash(passwordProvided,
                employee.PasswordSalt);
            if (hashedPassword.Equals(employee.Password))
            {
                return employee;
            }
            else
                return null;
        }

        public EmployeeViewModel GetUserByID(int id)
        {
            var user = _employeeRepository.GetSingle(id);
            if (user == null)
                return null;

            var employeeViewModel = _autoMapper.Map<EmployeeViewModel>(user);
            return employeeViewModel;
        }

        public List<ApplicantRequestViewModel> GetAllNewApplicants()
        {
            var newApplicants = _applicantRepository.GetAllNewApplicants();

            var newApplicantsViewModel = _autoMapper.Map<List<ApplicantRequestViewModel>>(newApplicants);

            return newApplicantsViewModel;
        }

        public bool MakeDecision(string action, int id)
        {
            var applicant = _applicantRepository.GetSingle(id);
            if (action == "approve")
            {
                applicant.Status = Common.Enums.ApplicantStatus.Approved;
                _applicantRepository.SaveChanges();

                //Create Member
                var member = _autoMapper.Map<Member>(applicant);
                member.ApplicantID = applicant.ID;
                member.DateCreated = DateTime.UtcNow;
                member.MembershipID = Common.Helpers.Encoder.Conceal(applicant.ID, 8);

                _memberRepository.Add(member);
                _memberRepository.SaveChanges();

                return true;
            }
            else
            {
                applicant.Status = Common.Enums.ApplicantStatus.Rejected;
                _applicantRepository.SaveChanges();

                return false;
            }
        }
    }
}
