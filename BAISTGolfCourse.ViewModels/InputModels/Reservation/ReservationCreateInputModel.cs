using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.InputModels.Reservation
{
    public class ReservationCreateInputModel
    {
        public ReservationCreateInputModel()
        {
            Reservations = new List<ReservationModel>();
        }

        [Required(ErrorMessage = "Required")]
        public int TeeTimeID { get; set; }
        public List<ReservationModel> Reservations { get; set; }


    }

    public class ReservationModel
    {
        public int MemberID { get; set; }
        public int Status { get; set; }
    }
}
