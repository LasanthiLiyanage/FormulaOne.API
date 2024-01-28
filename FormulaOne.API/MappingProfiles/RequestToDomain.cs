using AutoMapper;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Requests;

namespace FormulaOne.API.MappingProfiles
{
    public class RequestToDomain : Profile
    {
        public RequestToDomain()
        {
            CreateMap<CreateDriverAchievementRequest, Achievement>()
                .ForMember(
                    destinationMember: dest => dest.RaceWin,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => src.Wins))
                .ForMember(
                    destinationMember: dest => dest.State,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => 1))
                .ForMember(
                    destinationMember: dest => dest.AddedDate,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => DateTime.UtcNow))
                .ForMember(
                    destinationMember: dest => dest.UpdatedDate,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => DateTime.UtcNow));


            CreateMap<UpdateDriverAchievementRequest, Achievement>()
                .ForMember(
                    destinationMember: dest => dest.RaceWin,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => src.Wins))                
                .ForMember(
                    destinationMember: dest => dest.UpdatedDate,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => DateTime.UtcNow));


            CreateMap<CreateDriverRequest, Driver>()                
                .ForMember(
                    destinationMember: dest => dest.State,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => 1))
                .ForMember(
                    destinationMember: dest => dest.AddedDate,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => DateTime.UtcNow))
                .ForMember(
                    destinationMember: dest => dest.UpdatedDate,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => DateTime.UtcNow));

            CreateMap<UpdateDriverRequest, Driver>()               
                .ForMember(
                    destinationMember: dest => dest.UpdatedDate,
                    memberOptions: opt => opt.MapFrom(mapExpression: src => DateTime.UtcNow));

        }
    }
}
