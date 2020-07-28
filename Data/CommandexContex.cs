using Commander.Models;
using Microsoft.EntityFrameworkCore;

namespace Commander.Data
{
     public class CommanderContex : DbContext
     
     {
        public CommanderContex(DbContextOptions<CommanderContex> opt) : base(opt)
        {
            
        }

        public DbSet<Command> Commands {get;set;}

     }
}