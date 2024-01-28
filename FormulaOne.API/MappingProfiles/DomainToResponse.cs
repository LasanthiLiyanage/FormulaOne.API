using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;
using FormulaOne.Entities.Dtos.Responses;

namespace FormulaOne.API.MappingProfiles
{
    public class DomainToResponse : Profile
    {
        public DomainToResponse()
        {
            CreateMap<Achievement, DriverAchievementResponse>()
                .ForMember(
                    destinationMember: dest => dest.Wins,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => src.RaceWin));

            CreateMap<Driver, GetDriverResponse>()
                .ForMember(
                    destinationMember: dest => dest.DriverId,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => src.Id))
                .ForMember(
                    destinationMember: dest => dest.FullName,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => $"{src.LastName} {src.LastName}"));
        }
    }
}
