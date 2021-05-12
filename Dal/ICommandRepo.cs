using System.Collections.Generic;
using DotnetIntro.Models;

namespace DotnetIntro.Dal
{
    public interface ICommandRepo
    {
        IEnumerable<Command> GetAll();

        Command Find(int id);
    }
}
