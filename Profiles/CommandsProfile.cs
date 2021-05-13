using AutoMapper;
using DotnetIntro.Models;
using DotnetIntro.Presenters;
using DotnetIntro.Requests;

namespace DotnetIntro.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandPresenter>();
            CreateMap<CommandCreateRequest, Command>();
            CreateMap<CommandUpdateRequest, Command>();
            CreateMap<Command, CommandUpdateRequest>();
        }
    }
}