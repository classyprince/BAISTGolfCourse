using BAISTGolfCourse.Common.Helpers;
using BAISTGolfCourse.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data
{
    public class SeedDbEntities
    {
        public static void SeedSystemData(ClubBAISTEntities context)
        {
            //for (int i = 29; i < 40; i++)
            //{
            //    var member = new Applicant
            //    {
            //        FirstName = "Caleb" + i,
            //        LastName = "Daramola",
            //        EmailAddress = "cdaramola" + i + "@yahoo.ca",
            //        Address1 = "630 McAllister Loop SW",
            //        Address2 = "",
            //        AlternatePhone = "",
            //        Phone = "(647)608-1531",
            //        City = "Toronto",
            //        Province = "Ontario",
            //        PostalCode = "T6W 1N3",
            //        DateCreated = DateTime.UtcNow,
            //        DateOfBirth = new DateTime(1993, 2, 19),
            //        Status = Common.Enums.ApplicantStatus.Approved,
            //        Gender = Common.Enums.Gender.Male,
            //        HasShareHolderOneConfirmed = true,
            //        HasShareHolderTwoConfirmed = true,
            //        ShareHolder1ID = 1,
            //        ShareHolder2ID = 2
            //    };
            //    member.PasswordSalt = PasswordEncryptor.CreateSalt(5);
            //    member.Password = PasswordEncryptor.CreatePasswordHash("football2",
            //        member.PasswordSalt);

            //    context.Applicants.AddOrUpdate(p => p.EmailAddress, member);
            //}



            //context.SaveChanges();

            //var reservations = context.Reservations.OrderByDescending(x => x.DateCreated).ToList();
            //foreach (var reservation in reservations)
            //{
            //    var reservationModel = new PlayerScore
            //    {
            //        DateCreated = DateTime.Now,
            //        DatePlayed = DateTime.Now.AddDays(-1),
            //        HoleID = 2,
            //        HandicapID = 3,
            //        MemberID = reservation.MemberID,
            //        Score = 32,
            //        ReservationID = reservation.ID
            //    };
            //    context.PlayerScores.AddOrUpdate(p => p.ID, reservationModel);
            //}

            //context.SaveChanges();
            //var add2Member = new Member
            //{
            //    FirstName = "Caleb",
            //    LastName = "Daramola",
            //    EmailAddress = "cdaramola@yahoo.ca",
            //    Address1 = "630 McAllister Loop SW",
            //    Address2 = "",
            //    AlternatePhone = "",
            //    Phone = "(647)608-1531",
            //    City = "Toronto",
            //    Province = "Ontario",
            //    PostalCode = "T6W 1N3",
            //    DateCreated = DateTime.UtcNow,
            //    DateOfBirth = new DateTime(1993, 2, 19),
            //    MembershipID = "ABCED5Y",
            //    ApplicantID = null,
            //    Gender = Common.Enums.Gender.Male
            //};

            ////var firstMember = new Employee
            ////{
            ////    FirstName = "Clerk",
            ////    LastName = "Mason",
            ////    EmailAddress = "vtdaramolaAdmin@yahoo.ca",
            ////    Address1 = "630 McAllister Loop SW",
            ////    Address2 = "",
            ////    AlternatePhone = "",
            ////    Phone = "(647)608-1541",
            ////    City = "Toronto",
            ////    Province = "Ontario",
            ////    PostalCode = "T6W 1N3",
            ////    DateCreated = DateTime.UtcNow,
            ////    DateOfBirth = new DateTime(1993, 2, 19),
            ////    Gender = Common.Enums.Gender.Female,
            ////    Role = Common.Enums.Role.Administrator

            ////};
            //firstMember.PasswordSalt = PasswordEncryptor.CreateSalt(5);
            //firstMember.Password = PasswordEncryptor.CreatePasswordHash("football2",
            //    firstMember.PasswordSalt);

            //addMember.PasswordSalt = PasswordEncryptor.CreateSalt(5);
            //addMember.Password = PasswordEncryptor.CreatePasswordHash("football2",
            //    addMember.PasswordSalt);

            //add2Member.PasswordSalt = PasswordEncryptor.CreateSalt(5);
            //add2Member.Password = PasswordEncryptor.CreatePasswordHash("football2",
            //    addMember.PasswordSalt);

            //context.Applicants.AddOrUpdate(p => p.EmailAddress, firstMember);
            //context.Members.AddOrUpdate(p => p.EmailAddress, addMember);
            //context.Members.AddOrUpdate(p => p.EmailAddress, add2Member);

            //var golfClub = new GolfCourse
            //{
            //    Name = "BAIST Golf Course",
            //    DateAdded = DateTime.UtcNow,
            //    YearFounded = new DateTime(1991, 2, 2),
            //    Address = "630 McAllister Loop SW",
            //    City = "Edmonton",
            //    Country = "Canada",
            //    Rating = 70,
            //    Slope = 5

            //};

            //var golfClub2 = new GolfCourse
            //{
            //    Name = "Jasper Golf Course",
            //    DateAdded = DateTime.UtcNow,
            //    YearFounded = new DateTime(1991, 2, 2),
            //    Address = "630 McAllister Loop SW",
            //    City = "Edmonton",
            //    Country = "Canada",
            //    Rating = 75,
            //    Slope = 5
            //};

            //context.GolfCourses.AddOrUpdate(p => p.ID, golfClub);
            //context.GolfCourses.AddOrUpdate(p => p.ID, golfClub2);

            //context.SaveChanges();

            var teeTime = new TeeTime
            {
                DateCreated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(4).AddMinutes(-15),
                EndDate = DateTime.Now.AddDays(4),
                Status = Common.Enums.TeeTimeStatus.Open,
                GolfCourseID = 1
            };
            var teeTimeTwo = new TeeTime
            {
                DateCreated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(3).AddMinutes(-15),
                EndDate = DateTime.Now.AddDays(3),
                Status = Common.Enums.TeeTimeStatus.Open,
                GolfCourseID = 1
            };

            var teeTime3 = new TeeTime
            {
                DateCreated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(2).AddMinutes(-15),
                EndDate = DateTime.Now.AddDays(2),
                Status = Common.Enums.TeeTimeStatus.Open,
                GolfCourseID = 1
            };


            var teeTime4 = new TeeTime
            {
                DateCreated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(5).AddMinutes(-15),
                EndDate = DateTime.Now.AddDays(5),
                Status = Common.Enums.TeeTimeStatus.Open,
                GolfCourseID = 1
            };

            var teeTime5 = new TeeTime
            {
                DateCreated = DateTime.Now,
                StartDate = DateTime.Now.AddDays(6).AddMinutes(-15),
                EndDate = DateTime.Now.AddDays(6),
                Status = Common.Enums.TeeTimeStatus.Open,
                GolfCourseID = 1
            };

            context.TeeTimes.AddOrUpdate(p => p.ID, teeTime);
            context.TeeTimes.AddOrUpdate(p => p.ID, teeTimeTwo);
            context.TeeTimes.AddOrUpdate(p => p.ID, teeTime3);
            context.TeeTimes.AddOrUpdate(p => p.ID, teeTime4);
            context.TeeTimes.AddOrUpdate(p => p.ID, teeTime5);

            context.SaveChanges();

            //for (int i = 1; i < 6; i++)
            //{
            //    var hole = new Handicap
            //    {
            //        Name = "0 - 9"

            //    };
            //    context.Handicaps.AddOrUpdate(p => p.ID, hole);
            //}

            //context.SaveChanges();
        }

    }
}
