using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using BAISTGolfCourse.Repositories.IRepositories;
using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.Common.AutoMapper;
using BAISTGolfCourse.ViewModels.ViewModels.Member;
using BAISTGolfCourse.ViewModels.InputModels.Reservation;
using BAISTGolfCourse.ViewModels.ViewModels.Reservation;
using BAISTGolfCourse.Common.Enums;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class ReservationService : IReservationService
    {
        private readonly ITeeTimeRepository _teeTimeRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IEmployeeRepository _employeeRepository;

        private readonly IAutoMapper _autoMapper;
        public ReservationService(ITeeTimeRepository teeTimeRepository,
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

        public List<TeeTimeViewModel> FindTeeTimes(TeeTimeFinderModel teeTimeFinder)
        {
            var startDate = DateTime.Parse(teeTimeFinder.StartDate + " " + teeTimeFinder.StartTime);
            var endDate = DateTime.Parse(teeTimeFinder.EndDate + " " + teeTimeFinder.EndTime);

            var teeTimes = _teeTimeRepository.GetList(startDate, endDate);

            var teeTimesViewModel = teeTimes.Select(x => new TeeTimeViewModel
            {
                StartDate = x.StartDate,
                EndDate = x.EndDate,
                Status = x.Status,
                ID = x.ID,
                ReservationCount = x.Reservations.Count
            });

            return teeTimesViewModel.ToList();
        }

        public MemberViewModel AddMemberToReservation(string memberID, int teeTimeID,
            string currentMemberID)
        {

            Member member = _memberRepository.FindBy(x => x.EmailAddress == memberID)
                .SingleOrDefault();

            if (member == null)
            {
                memberID = memberID.ToLower();
                member = _memberRepository.FindBy(x => x.MembershipID.ToLower() == memberID).
                SingleOrDefault();
            }


            if (member != null)
            {
                if (member.MembershipID.ToLower() == currentMemberID.ToLower())
                {
                    return null;
                }

                var reservation = _reservationRepository.FindBy(x => x.MemberID == member.ID
                && x.TeeTimeID == teeTimeID).SingleOrDefault();

                if (reservation != null)
                {
                    return null;
                }
                var memberViewModel = _autoMapper.Map<MemberViewModel>(member);

                return memberViewModel;
            }
            else
            {
                return null;
            }
        }

        public List<MemberViewModel> AddMemberToReservationDB(string memberID, int teeTimeID)
        {
            var listOfMembersInTeeTime = new List<MemberViewModel>();

            Member member = _memberRepository.FindBy(x => x.EmailAddress == memberID).SingleOrDefault();

            if (member == null)
                member = _memberRepository.FindBy(x => x.MembershipID == memberID).
                SingleOrDefault();

            if (member != null)
            {
                var reservation = new Reservation
                {
                    DateCreated = DateTime.UtcNow,
                    MemberID = member.ID,
                    TeeTimeID = teeTimeID,
                    Status = ReservationStatus.NotAccepted
                };

                //TODO Send Email To Members Invited

                _reservationRepository.Add(reservation);
                _reservationRepository.SaveChanges();

                var memberViewModel = _autoMapper.Map<MemberViewModel>(member);
                listOfMembersInTeeTime.Add(memberViewModel);
                return listOfMembersInTeeTime;
            }
            else
            {
                return listOfMembersInTeeTime;
            }
        }

        public bool CreateReservation(ReservationCreateInputModel inputModel, string currentMemberID)
        {
            var currentMember = _memberRepository.FindBy(x => x.EmailAddress ==
            currentMemberID).SingleOrDefault();

            var checkReservation = _reservationRepository.FindBy(x => x.MemberID ==
            currentMember.ID &&
            x.TeeTimeID == inputModel.TeeTimeID).SingleOrDefault();

            if (checkReservation == null)
            {
                //Create Reservation For Current Member
                var reservationMember = new Reservation
                {
                    DateCreated = DateTime.UtcNow,
                    Status = ReservationStatus.Accepted,
                    MemberID = currentMember.ID,
                    TeeTimeID = inputModel.TeeTimeID
                };
                _reservationRepository.Add(reservationMember);
                _reservationRepository.SaveChanges();


                if (inputModel.Reservations.Count > 0)
                {
                    foreach (var reservation in inputModel.Reservations)
                    {
                        var check = _reservationRepository.FindBy(x => x.MemberID ==
                        reservation.MemberID &&
                        x.TeeTimeID == inputModel.TeeTimeID).SingleOrDefault();

                        if (check == null)
                        {
                            var newReservation = new Reservation
                            {
                                DateCreated = DateTime.UtcNow,
                                Status = (ReservationStatus)reservation.Status,
                                MemberID = reservation.MemberID,
                                TeeTimeID = inputModel.TeeTimeID
                            };
                            _reservationRepository.Add(newReservation);
                            _reservationRepository.SaveChanges();
                        }
                    }
                }
                return true;
            }

            return false;
        }

        public List<ReservationViewModel> GetReservations(string email)
        {
            var member = _memberRepository.FindBy(x => x.EmailAddress == email).SingleOrDefault();

            var reservations = _reservationRepository.GetListForMember(member.ID);
            var reservationViewModels = _autoMapper.
                Map<List<ReservationViewModel>>(reservations);

            return reservationViewModels;
        }
    }
}
