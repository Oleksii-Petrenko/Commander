using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Models;
using Commander.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{


    // api/commands
    [Route("api/commands/")]
    [ApiController]
    public class CommandsController: ControllerBase
    {
        #region DEPENDENCY INJECTION
        private readonly ICommanderRepo _repository;

        public IMapper _mapper { get; }

        // private readonly MockCommanderRepo _repository = new MockCommanderRepo();
        public CommandsController(ICommanderRepo repository, IMapper mapper )
        {
            _repository=repository;
            _mapper = mapper;

        }
        #endregion
         

        // GET api/commands
        [HttpGet]
        public ActionResult <IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();

            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id} 
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem !=null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();

        }

        // POST api/commands
        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandReadDto commandCreateDto)
        {
            var coommandModel = _mapper.Map<Command>(commandCreateDto);
            _repository.CreateCommand(coommandModel);
            _repository.SaveChanges();

             var commandReadDto = _mapper.Map<CommandReadDto>(coommandModel);

            
            return CreatedAtRoute(nameof(GetCommandById), new {Id = CommandReadDto.Id}, commandReadDto );
 
        }


        //PUT api/commands/{id}
        [HttpGet("{id}")]
        public ActionResult UpdateCommand(int id,CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null)
            {
                return NotFound();
            }
            _mapper.Map(commandUpdateDto,commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();

        }




    }

}