using BAISTGolfCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public class Reservation
    {
        public Reservation()
        {
            PlayerScores = new HashSet<PlayerScore>();
        }
        public int ID { get; set; }
        public int TeeTimeID { get; set; }
        public int MemberID { get; set; }
        public TeeTime TeeTime { get; set; }
        public Member Member { get; set; }
        public DateTime DateCreated { get; set; }
        public ReservationStatus Status { get; set; }
        public ICollection<PlayerScore> PlayerScores { get; set; }
    }
}
