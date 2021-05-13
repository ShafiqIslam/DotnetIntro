using System.Collections.Generic;
using AutoMapper;
using DotnetIntro.Dal;
using DotnetIntro.Models;
using DotnetIntro.Presenters;
using DotnetIntro.Requests;
using Microsoft.AspNetCore.JsonPatch;
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

        [HttpGet("{id}", Name="Find")]
        public ActionResult <CommandPresenter> Find(int id)
        {
            var command = _repo.Find(id);
            if (command == null) return NotFound();
            return Ok(_mapper.Map<CommandPresenter>(command));
        }

        [HttpPost]
        public ActionResult<CommandPresenter> Create(CommandCreateRequest request)
        {
            var command = _mapper.Map<Command>(request);
            _repo.Add(command);
            _repo.Save();
            var response = _mapper.Map<CommandPresenter>(command);
            return CreatedAtRoute(nameof(Find), new {Id = command.Id, response});
        }

        [HttpPut("{id}")]
        public ActionResult Update(int id, CommandUpdateRequest request)
        {
            var command = _repo.Find(id);
            if (command == null) return NotFound();
            _mapper.Map(request, command);
            _repo.Update(command);
            _repo.Save();
            return NoContent();
        }
        
        [HttpPatch("{id}")]
        public ActionResult PartialUpdate(int id, JsonPatchDocument<CommandUpdateRequest> request)
        {
            var command = _repo.Find(id);
            if (command == null) return NotFound();

            var commandToPatch = _mapper.Map<CommandUpdateRequest>(command);
            request.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch)) return ValidationProblem(ModelState);

            _mapper.Map(commandToPatch, command);
            _repo.Update(command);
            _repo.Save();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var command = _repo.Find(id);
            if (command == null) return NotFound();

            _repo.Delete(command);
            _repo.Save();
            return NoContent();
        }
    }
}