using System;
using System.Collections.Generic;
using System.Linq;
using DotnetIntro.Models;

namespace DotnetIntro.Dal
{
    public class SqlCommandRepo : ICommandRepo 
    {
        private readonly CommanderContext _context;

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public SqlCommandRepo(CommanderContext context)
        {
            _context = context;
        }

        public IEnumerable<Command> GetAll()
        {
            return _context.Commands.ToList();
        }

        public Command Find(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            _context.Commands.Add(command);
        }

        public void Update(Command command)
        {
            
        }

        public void Delete(Command command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            _context.Commands.Remove(command);
        }
    }
}