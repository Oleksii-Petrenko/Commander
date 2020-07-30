using AutoMapper;
using Commander.Models;
using Commander.ReadDto;

namespace Commander.Profiles

{
        public class CommanderProfile : Profile
        {
            public CommanderProfile()
            {
             
                CreateMap<Command,CommandReadDto>();

            }
            


        }


}