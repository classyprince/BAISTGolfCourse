using AutoMapper;
using BAISTGolfCourse.Common.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAISTGolfCourse.ViewModels.Mappings.Reservation
{
    public class ReservationViewModel : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<Data.Models.Reservation, ViewModels.Reservation.ReservationViewModel>()
               .ForMember(dest => dest.MemberFullName, opt => opt.MapFrom(src => 
               src.Member.FirstName + " " + src.Member.LastName));
        }
    }
}
