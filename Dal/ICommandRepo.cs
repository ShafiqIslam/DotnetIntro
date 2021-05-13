using System.Collections.Generic;
using DotnetIntro.Models;

namespace DotnetIntro.Dal
{
    public interface ICommandRepo
    {
        bool Save();

        IEnumerable<Command> GetAll();

        Command Find(int id);

        void Add(Command command);
        
        void Update(Command command);
        
        void Delete(Command command);
    }
}
