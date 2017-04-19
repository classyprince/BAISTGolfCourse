using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.BLL.ServiceInterfaces
{
    public interface IEmailService
    {
        void SendEmailToApplicant(string emailAddress, string firstName);
        void SendEmailToSponsors(string emailAddress, string applicantName, string firstName);
    }
}
