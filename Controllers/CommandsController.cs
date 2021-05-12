using System.Collections.Generic;
using AutoMapper;
using DotnetIntro.Dal;
using DotnetIntro.Presenters;
using Microsoft.AspNetCore.Mvc;

namespace DotnetIntro.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepo _repo;
        private readonly IMapper _mapper;

        public CommandsController(ICommandRepo repo, IMapper mapper)
        {
            this._repo = repo;
            this._mapper = mapper;
        }

        [HttpGet]
        public ActionResult <IEnumerable<CommandPresenter>> Index()
        {
            var commands = _repo.GetAll();
            return Ok(_mapper.Map<IEnumerable<CommandPresenter>>(commands));
        }

        [HttpGet("{id}")]
        public ActionResult <CommandPresenter> Find(int id)
        {
            var command = _repo.Find(id);
            if (command == null) return NotFound();
            return Ok(_mapper.Map<CommandPresenter>(command));
        }
    }
}