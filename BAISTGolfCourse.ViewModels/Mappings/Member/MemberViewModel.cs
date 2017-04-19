using AutoMapper;
using BAISTGolfCourse.Common.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.Mappings.Member
{
    public class MemberViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Models.Member, ViewModels.Member.MemberViewModel>()
                 .ForMember(dest => dest.AverageScore, opt => opt.Ignore())
                .ForMember(dest => dest.ReservationStats, opt => opt.Ignore());

            Mapper.CreateMap<Data.Models.TeeTime, ViewModels.Reservation.TeeTimeWithMembersViewModel>()
                .ForMember(dest => dest.MembersReserved, opt => opt.Ignore());

            Mapper.CreateMap<Data.Models.Applicant, Data.Models.Member>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.PreviousApplication, opt => opt.Ignore())
                .ForMember(dest => dest.PlayerScores, opt => opt.Ignore())
                .ForMember(dest => dest.ApplicantID, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .ForMember(dest => dest.MembershipID, opt => opt.Ignore())
                .ForMember(dest => dest.Reservations, opt => opt.Ignore())
                .ForMember(dest => dest.Applicants, opt => opt.Ignore());
        }
    }
}
