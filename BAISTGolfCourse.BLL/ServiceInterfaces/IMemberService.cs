using BAISTGolfCourse.Data.Models;
using BAISTGolfCourse.ViewModels.InputModels.Applicant;
using BAISTGolfCourse.ViewModels.ViewModels.Member;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.BLL.ServiceInterfaces
{
    public interface IMemberService
    {
        Member GetMemberByMembershipNumber(string membershipNumber);
        MemberViewModel GetMemberByEmail(string emailAddress);
        MemberViewModel GetMemberByMembershipID(string membershipID);
    }
}
