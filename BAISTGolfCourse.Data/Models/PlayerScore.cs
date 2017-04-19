using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public class PlayerScore
    {
        public long ID { get; set; }
        public int MemberID { get; set; }
        public int ReservationID { get; set; }
        public int HoleID { get; set; }
        public double Score { get; set; }
        public int? HandicapID { get; set; }
        public Handicap Handicap { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DatePlayed { get; set; }
        public Member Member { get; set; }
        public Reservation Reservation { get; set; }
        public Hole Hole { get; set; }
    }
}
