using BAISTGolfCourse.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.ViewModels.Reservation
{
    public class TeeTimeViewModel
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TeeTimeStatus Status { get; set; }

        public int ReservationCount { get; set; }
    }
}
