using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Models;
using Commander.ReadDto;
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
        [HttpGet("{id}")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem !=null)
            {
                return Ok(_mapper.Map<CommandReadDto>(commandItem));
            }

            return NotFound();

        }
    }

}