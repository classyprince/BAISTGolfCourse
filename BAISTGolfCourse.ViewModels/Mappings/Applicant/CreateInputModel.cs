using AutoMapper;
using BAISTGolfCourse.Common.AutoMapper;
using BAISTGolfCourse.Common.Enums;
using System;

namespace BAISTGolfCourse.ViewModels.Mappings.Applicant
{
    public class CreateInputModel : IAutoMapperTypeConfigurator
    {
        public void Configure()
        {
            Mapper.CreateMap<InputModels.Applicant.CreateInputModel, Data.Models.Applicant>()
                .ForMember(dest => dest.ID, opt => opt.Ignore())
                .ForMember(dest => dest.ShareHolder1, opt => opt.Ignore())
                .ForMember(dest => dest.ShareHolder2, opt => opt.Ignore())
                .ForMember(dest => dest.HasShareHolderOneConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.HasShareHolderTwoConfirmed, opt => opt.Ignore())
                .ForMember(dest => dest.ShareHolder1ID, opt => opt.Ignore())
                .ForMember(dest => dest.Gender, opt => opt.Ignore())
                .ForMember(dest => dest.RejectionReason, opt => opt.Ignore())
                .ForMember(dest => dest.ShareHolder2ID, opt => opt.Ignore())
                .ForMember(dest => dest.ProspectiveMembers, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
                .ForMember(dest => dest.DateCreated, opt => opt.Ignore())
                .AfterMap((src, dest) =>
                    {
                        dest.Status = ApplicantStatus.Initiated;
                        dest.DateCreated = DateTime.UtcNow;
                        dest.Gender = (src.Gender) ? Gender.Male : Gender.Female;
                    });

            Mapper.CreateMap<Data.Models.Applicant, ViewModels.Applicant.ApplicantViewModel>();

            Mapper.CreateMap<Data.Models.Applicant, ViewModels.Applicant.ApplicantRequestViewModel>()
                 .ForMember(dest => dest.FirstShareHolder, opt => opt.MapFrom(src => src.ShareHolder1))
                .ForMember(dest => dest.SecondShareHolder, opt => opt.MapFrom(src => src.ShareHolder2));
        }
    }
}
