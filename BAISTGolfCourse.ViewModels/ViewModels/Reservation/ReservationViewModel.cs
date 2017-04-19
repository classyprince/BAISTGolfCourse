using System;

namespace BAISTGolfCourse.ViewModels.ViewModels.Reservation
{
    public class ReservationViewModel
    {
        public string MemberFullName { get; set; }
        public int TeeTimeID { get; set; }
        public DateTime TeeTimeStartDate { get; set; }
        public DateTime TeeTimeEndDate { get; set; }
        public string DateCreated { get; set; }
    }
}