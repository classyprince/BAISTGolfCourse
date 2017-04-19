using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.ViewModels.InputModels.Applicant;
using BAISTGolfCourse.ViewModels.InputModels.Reservation;
using BAISTGolfCourse.ViewModels.ViewModels.Member;
using BAISTGolfCourse.ViewModels.ViewModels.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.BLL.ServiceInterfaces
{
    public interface ITeeTimeService
    {
        TeeTimeWithMembersViewModel GetWithMembers(int id);
    }
}
