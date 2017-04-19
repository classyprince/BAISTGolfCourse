using BAISTGolfCourse.BLL.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BAISTGolfCourse.ViewModels.InputModels.PlayerScore;
using BAISTGolfCourse.Repositories.IRepositories;
using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.ViewModels.ViewModels.PlayerScore;
using System.Globalization;
using BAISTGolfCourse.Common.Enums;

namespace BAISTGolfCourse.BLL.ServiceImpl
{
    public class PlayerScoreService : IPlayerScoreService
    {
        private readonly IHoleRepository _holeRepository;
        private readonly IPlayerScoreRepository _playerScoreRepository;
        private readonly IReservationRepository _reservationRepository;
        private readonly IGolfCourseRepository _golfCourseRepository;
        private readonly IHandicapRepository _handicapRepository;
        private readonly IMemberRepository _memberRepository;
        public PlayerScoreService(IHoleRepository holeRepository,
            IPlayerScoreRepository playerScoreRepository,
            IReservationRepository reservationRepository,
            IGolfCourseRepository golfCourserepository,
            IHandicapRepository handicapRepository,
            IMemberRepository memberRepository)
        {
            _holeRepository = holeRepository;
            _playerScoreRepository = playerScoreRepository;
            _reservationRepository = reservationRepository;
            _golfCourseRepository = golfCourserepository;
            _handicapRepository = handicapRepository;
            _memberRepository = memberRepository;
        }

        public CreateInputModel GetInputModel(string userIdentity)
        {
            var createInputModel = new CreateInputModel();

            var holes = _holeRepository.GetAll().ToList();

            var handicaps = _handicapRepository.GetAll().ToList();

            var member = _memberRepository.FindBy(x => x.EmailAddress == userIdentity).SingleOrDefault();

            var reservations = _reservationRepository.GetNormalListForMember(member.ID).ToList();

            createInputModel.Holes = holes.Select
             (x => (new HoleViewModel { ID = x.ID, Name = x.Name })).ToList();

            createInputModel.Handicaps = handicaps.Select
             (x => (new HandicapViewModel { ID = x.ID, Name = x.Name })).ToList();

            createInputModel.Reservations = reservations.Select
            (x => (new ReservationScoreViewModel { ID = x.ID, Date = x.TeeTime.StartDate.ToString("f") 
            + " - " + x.TeeTime.EndDate.ToString("f") })).ToList();

            return createInputModel;
        }

        public List<ReservationScoreViewModel> GetReservationsForMember(string memberID)
        {
            var member = _memberRepository.FindBy(x => x.MembershipID == memberID).SingleOrDefault();

            var reservations = _reservationRepository.FindBy(x => x.MemberID == member.ID).ToList();

            return  reservations.Select
            (x => (new ReservationScoreViewModel
            {
                ID = x.ID,
                Date = x.TeeTime.StartDate.ToString("f")
            + " - " + x.TeeTime.EndDate.ToString("f")
            })).ToList();
        }

        public CreateInputModelWithMember GetInputModelForAdmin()
        {
            var createInputModel = new CreateInputModelWithMember();

            var holes = _holeRepository.GetAll().ToList();

            var handicaps = _handicapRepository.GetAll().ToList();

            var golfCourse = _golfCourseRepository.FindBy(x => x.Name.Contains(
                "BAIST")).FirstOrDefault();

            createInputModel.Holes = holes.Select
             (x => (new HoleViewModel { ID = x.ID, Name = x.Name })).ToList();

            createInputModel.Handicaps = handicaps.Select
             (x => (new HandicapViewModel { ID = x.ID, Name = x.Name })).ToList();


            return createInputModel;
        }

        public CreateInputModel CreatePlayerScore(CreateInputModel model, string userIdentity)
        {
            var member = _memberRepository.FindBy(x => x.EmailAddress == userIdentity).
                SingleOrDefault();

            var reservation = _reservationRepository.GetWithGolfCourse(model.ReservationID);

            var golfCourse = reservation.TeeTime.GolfCourse;

            var calculatedScore = model.Score - golfCourse.Rating;

            var playerScoreModel = new PlayerScore
            {
                ReservationID = model.ReservationID,
                MemberID = member.ID,
                Score = calculatedScore,
                HoleID = model.HoleID,
                HandicapID = model.HandicapID,
                DateCreated = DateTime.UtcNow,
                DatePlayed = model.DatePlayed.Value,
            };

            _playerScoreRepository.Add(playerScoreModel);
            _playerScoreRepository.SaveChanges();

            return model;
        }

        public CreateInputModelWithMember CreatePlayerScore(CreateInputModelWithMember model)
        {
            var member = _memberRepository.FindBy(x => x.MembershipID == model.MemberID).
                SingleOrDefault();

            var playerScoreModel = new PlayerScore
            {
                ReservationID = model.ReservationID,
                MemberID = member.ID,
                Score = model.Score,
                HoleID = model.HoleID,
                HandicapID = model.HandicapID,
                DateCreated = DateTime.UtcNow,
                DatePlayed = model.DatePlayed.Value,
            };

            _playerScoreRepository.Add(playerScoreModel);
            _playerScoreRepository.SaveChanges();

            return model;
        }

        public ScoreReport GetWeeklyReport(string userIdentity)
        {
            var user = _memberRepository.FindBy(x => x.EmailAddress == userIdentity).SingleOrDefault();

            var weeklyScoreReport = new ScoreReport();

            if (user != null)
            {
                var weeklyScore = new List<double>();

                var monthlyScore = new List<double>();

                var allMemberScores = _playerScoreRepository.FindBy(x =>
                x.MemberID == user.ID).ToList();

                if (allMemberScores.Count > 0)
                {
                    //Weekly Score Report
                    var currentWeekScore = allMemberScores.Where(x =>
                    GetWeekOfYear(x.DatePlayed) == GetWeekOfYear(DateTime.Now)).ToList();

                    if (currentWeekScore.Count > 0)
                    {
                        foreach (var day in weeklyScoreReport.DaysOfWeeks)
                        {
                            var score = currentWeekScore.Where(x => x.DatePlayed.
                            DayOfWeek.ToString()
                            == day).SingleOrDefault();

                            if (score != null)
                            {
                                weeklyScore.Add(score.Score);
                            }
                            else
                            {
                                weeklyScore.Add(0);
                            }                          
                        }
                    }

                    //Monthly Score
                    var currentMonthScore = allMemberScores.Where(x =>
                    x.DatePlayed.Year == DateTime.Now.Year).ToList();

                    if (currentMonthScore.Count > 0)
                    {
                        foreach (var month in weeklyScoreReport.MonthsOfYears)
                        {
                            var score = currentMonthScore.Where(x => x.DatePlayed.ToString("MMMM")
                            == month).ToList();                    

                            if (score.Count > 0)
                            {
                                var scoreAverage = score.Select(x => x.Score).Sum() / score.Count();
                                monthlyScore.Add(scoreAverage);
                            }
                            else
                            {
                                monthlyScore.Add(0);
                            }
                        }
                    }

                    //Year Scores
                    var yearScore = allMemberScores.Where(x => x.DatePlayed.Year 
                    == DateTime.Now.Year).ToList();

                    if (yearScore.Count > 0)
                    {
                        weeklyScoreReport.Years.Add(DateTime.Now.Year.ToString());
                        weeklyScoreReport.YearAverageScores.Add(yearScore.Select(x => x.Score).Sum() / yearScore.Count);
                    }

                }

            }
            return weeklyScoreReport;
        }

        private int GetWeekOfYear(DateTime date)
        {
            var currentCulture = CultureInfo.CurrentCulture;
            var weekNoToday = currentCulture.Calendar.GetWeekOfYear(date,
                            currentCulture.DateTimeFormat.CalendarWeekRule,
                            currentCulture.DateTimeFormat.FirstDayOfWeek);
            return weekNoToday;
        }

        public List<UserScoreViewModel> GetAllUserScores()
        {
            var playerScores = _playerScoreRepository.GetAllPlayerScores().Select(
                x => new UserScoreViewModel
                {
                    FullName = x.Member.FirstName + " " + x.Member.LastName,
                    Gender = x.Member.Gender.ToString(),
                    Handicap = x.Handicap.Name,
                    Score = x.Score.ToString(),
                    Date = x.DatePlayed.ToString("f")
                }).ToList();

            return playerScores;
        }

        public List<UserScoreViewModel> GetAllUserScoresMale()
        {
            var playerScores = _playerScoreRepository.GetAllPlayerScores().Where(x => x.Member.Gender == Gender.Male).Select(
                x => new UserScoreViewModel
                {
                    FullName = x.Member.FirstName + " " + x.Member.LastName,
                    Gender = x.Member.Gender.ToString(),
                    Handicap = x.Handicap.Name,
                    Score = x.Score.ToString(),
                    Date = x.DatePlayed.ToString("f")
                }).ToList();

            return playerScores;
        }

        public List<UserScoreViewModel> GetAllUserScoresFemale()
        {
            var playerScores = _playerScoreRepository.GetAllPlayerScores().Where( x=> x.Member.Gender == Gender.Female).Select(
                x => new UserScoreViewModel
                {
                    FullName = x.Member.FirstName + " " + x.Member.LastName,
                    Gender = x.Member.Gender.ToString(),
                    Handicap = x.Handicap.Name,
                    Score = x.Score.ToString(),
                    Date = x.DatePlayed.ToString("f")
                }).ToList();

            return playerScores;
        }
    }
}
