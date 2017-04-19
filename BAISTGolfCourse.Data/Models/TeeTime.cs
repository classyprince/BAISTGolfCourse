using BAISTGolfCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.Data.Models
{
    public class TeeTime
    {
        public TeeTime()
        {
            Reservations = new HashSet<Reservation>();
        }
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GolfCourseID { get; set; }
        public DateTime DateCreated { get; set; }
        public TeeTimeStatus Status { get; set; }
        public GolfCourse GolfCourse { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
