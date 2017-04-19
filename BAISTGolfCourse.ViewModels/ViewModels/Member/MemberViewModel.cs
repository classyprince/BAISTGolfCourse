using BAISTGolfCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.ViewModels.Member
{
    public class MemberViewModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public int ApplicantID { get; set; }
        public string MembershipID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public Gender Gender { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }

        public ReservationStats ReservationStats { get; set; }
        public AverageScore AverageScore { get; set; }
    }

    public class ReservationStats
    {
        public int ReservationWeek { get; set; }
        public int ReservationMonth { get; set; }
        public int ReservationYear { get; set; }
        public int ReservationAll { get; set; }
    }

    public class AverageScore
    {
        public double ScoreWeek { get; set; }
        public double ScoreMonth { get; set; }
        public double ScoreYear { get; set; }

    }
}
