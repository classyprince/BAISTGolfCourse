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
using BAISTGolfCourse.ViewModels.ViewModels.Member;
using BAISTGolfCourse.Common.AutoMapper;
using System.Globalization;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class MemberService : IMemberService
    {
        private readonly IApplicantRepository _applicantRepository;
        private readonly IMemberRepository _memberRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IPlayerScoreRepository _playerScoreRepository;
        private readonly IAutoMapper _autoMapper;

        public MemberService(IApplicantRepository applicantRepository,
            IMemberRepository memberRepository, 
            IReservationRepository reservationRepository,
            IPlayerScoreRepository playerScoreRepository,
            IAutoMapper autoMapper)
        {
            _applicantRepository = applicantRepository;
            _memberRepository = memberRepository;
            _reservationRepository = reservationRepository;
            _playerScoreRepository = playerScoreRepository;
            _autoMapper = autoMapper;
        }

        public Member GetMemberByMembershipNumber(string membershipNumber)
        {
            var member = _memberRepository.FindBy(x => x.MembershipID == membershipNumber).
                SingleOrDefault();
            return member;
        }

        public MemberViewModel GetMemberByEmail(string emailAddress)
        {
            var member = _memberRepository.FindBy(x => x.EmailAddress == emailAddress).
                SingleOrDefault();
            if (member == null)
            {
                return null;
            }
            var memberViewModel = _autoMapper.Map<MemberViewModel>(member);
            return memberViewModel;
        }

        public MemberViewModel GetMemberByMembershipID(string membershipID)
        {
            var member = _memberRepository.FindBy(x => x.MembershipID == membershipID).
                SingleOrDefault();
            if (member == null)
            {
                return null;
            }
            var memberViewModel = _autoMapper.Map<MemberViewModel>(member);
            memberViewModel.AverageScore = ScoreReport(member);
            memberViewModel.ReservationStats = ReservationShortReport(member);
            return memberViewModel;
        }

        public AverageScore ScoreReport(Member member)
        {
            var averageScore = new AverageScore();

            var allMemberScores = _playerScoreRepository.FindBy(x => 
            x.MemberID == member.ID).ToList();

            if (allMemberScores.Count > 0)
            {
                //Week Score 
                var weekScore = allMemberScores.Where(x =>
                GetWeekOfYear(x.DatePlayed) == GetWeekOfYear(DateTime.Now));

                var actualWeekScore = 0.0;
                if (weekScore.Count() > 0)
                    actualWeekScore = weekScore.Select(x => x.Score).Sum() / weekScore.Count();

                //Month Score
                var monthScore = allMemberScores.Where(x =>
               x.DatePlayed.Month == DateTime.Now.Month);

                var actualMonthScore = 0.0;
                if (monthScore.Count() > 0)
                    actualMonthScore = monthScore.Select(x => x.Score).Sum() / monthScore.Count();

                //Year Score
                var yearScore = allMemberScores.Where(x =>
               x.DatePlayed.Year == DateTime.Now.Year);

                var actualYearScore = 0.0;
                if (yearScore.Count() > 0)
                    actualYearScore = yearScore.Select(x => x.Score).Sum() / yearScore.Count();

                averageScore.ScoreMonth = actualMonthScore;
                averageScore.ScoreWeek = actualWeekScore;
                averageScore.ScoreYear = actualYearScore;
            }         

            return averageScore;

        }

        public ReservationStats ReservationShortReport(Member member)
        {
            var reservationStat = new ReservationStats();

            //Get All Reservation
            var allReservations = _reservationRepository.GetListReportForMember(member.ID);

            if (allReservations.Count > 0)
            {
                //Week Reservation 
                var weekReservation = allReservations.Where(x =>
                GetWeekOfYear(x.TeeTime.StartDate) == GetWeekOfYear(DateTime.Now)).Count();

                //Month Reservation
                var monthReservation = allReservations.Where(x =>
               x.TeeTime.StartDate.Month == DateTime.Now.Month).Count();

                //Year Reservation
                var yearReservation = allReservations.Where(x =>
               x.TeeTime.StartDate.Year == DateTime.Now.Year).Count();

                reservationStat.ReservationAll = allReservations.Count;
                reservationStat.ReservationMonth = monthReservation;
                reservationStat.ReservationWeek = weekReservation;
                reservationStat.ReservationYear = yearReservation;
            }          

            return reservationStat;



        }

        private int GetWeekOfYear(DateTime date)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var weekNoToday = currentCulture.Calendar.GetWeekOfYear(date,
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);
            return weekNoToday;
        }
    }
}
