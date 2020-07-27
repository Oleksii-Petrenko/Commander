using System.Collections.Generic;
using Commander.Models;

namespace Commander.Data
{
    public class Mock : ICommanderRepo

    {
        public IEnumerable<Command> GetAppCommands()
        {
            var commands = new List<Command>
             {
                 new Command{Id=0, HowTo="111111111111Boil an egg",Line="1111111111111Boil water", Platform="1111111111111111Kettle & Pan"},
                 new Command{Id=1, HowTo="111111111111Cut bread",Line="111111111111111Get a knife", Platform="111111111111111knife $ choping board"},
                 new Command{Id=2, HowTo="1111111111111Make cup of tea",Line="11111111111111Place teabag an cup", Platform="111111111111111111Kettle $ cup"}    

             };
            
             return commands;
        }
 
        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="111111111111111Boil an egg",Line="1111111111111Boil water", Platform="111111111111111Kettle & Pan"};
        }
    }

}