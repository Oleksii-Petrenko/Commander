using AutoMapper;
using Commander.Models;
using Commander.Dtos;

namespace Commander.Profiles

{
        public class CommanderProfile : Profile
        {
            public CommanderProfile()
            {
                // Sourse -> Target
                CreateMap<Command,CommandReadDto>();
                CreateMap<CommandCreateDto,Command>();
                CreateMap<CommandUpdateDto,Command>();

            }
            


        }


}