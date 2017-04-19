using BAISTGolfCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public partial class Member
    {
        public Member()
        {
            Applicants = new HashSet<Applicant>();
            Reservations = new HashSet<Reservation>();
            PlayerScores = new HashSet<PlayerScore>();
        }
        public int ID { get; set; }
        public string MembershipID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public int? ApplicantID { get; set; }
        public string PasswordSalt { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public Gender Gender { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string AlternatePhone { get; set; }
        public Applicant PreviousApplication { get; set; }
        public ICollection<Applicant> Applicants { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
        public ICollection<PlayerScore> PlayerScores { get; set; }
    }
}
