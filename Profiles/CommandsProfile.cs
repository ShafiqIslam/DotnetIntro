using AutoMapper;
using DotnetIntro.Models;
using DotnetIntro.Presenters;

namespace DotnetIntro.Profiles
{
    public class CommandsProfile : Profile
    {
        public CommandsProfile()
        {
            CreateMap<Command, CommandPresenter>();
        }
    }
}