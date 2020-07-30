using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data

 {
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContex _context;

        public SqlCommanderRepo(CommanderContex context)
        {
            _context = context;
        }
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id==id);
        }
    }


}