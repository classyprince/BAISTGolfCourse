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
using BAISTGolfCourse.ViewModels.InputModels.Reservation;
using BAISTGolfCourse.ViewModels.ViewModels.Reservation;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class TeeTimeService : ITeeTimeService
    {
        private readonly ITeeTimeRepository _teeTimeRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IAutoMapper _autoMapper;
        public TeeTimeService(ITeeTimeRepository teeTimeRepository, 
            IReservationRepository reservationRepository,
            IMemberRepository memberRepository,
            IEmployeeRepository employeeRepository, IAutoMapper autoMapper)
        {
            _teeTimeRepository = teeTimeRepository;
            _reservationRepository = reservationRepository;
            _memberRepository = memberRepository;
            _employeeRepository = employeeRepository;
            _autoMapper = autoMapper;
        }

        public TeeTimeWithMembersViewModel GetWithMembers(int id)
        {
            var teeTime = _teeTimeRepository.GetWithMembers(id);

            var teeTimeViewModel = _autoMapper.Map<TeeTimeWithMembersViewModel>(teeTime);

            var membersReserved = teeTime.Reservations.Select(x => x.Member);

            teeTimeViewModel.MembersReserved = _autoMapper.Map<List<MemberViewModel>>(membersReserved);

            return teeTimeViewModel;
        }
    }
}
