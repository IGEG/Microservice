using AutoMapper;
using CommandsService.Dtos;
using CommandsService.Models;
using PlatformServices;

namespace CommandsService.Profiles
{
    public class Commandsprofile : Profile
    {
        public Commandsprofile()
        {
            
            CreateMap<Message, DtoReadMessage>();
            CreateMap<DtoCreateCommands, Command>();
            CreateMap<Command, DtoReadCommand>();
            CreateMap<PlatformPublishedDto, Platform>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.Id));
            CreateMap<GrpcPlatformModel, Platform>()
                .ForMember(dest => dest.ExternalID, opt => opt.MapFrom(src => src.PlatformId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Commands, opt => opt.Ignore());
        }
    }
}