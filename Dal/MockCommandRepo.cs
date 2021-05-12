using System.Collections.Generic;
using DotnetIntro.Models;

namespace DotnetIntro.Dal
{
    public class MockCommandRepo : ICommandRepo
    {
        public Command Find(int id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle and pan"};
        }

        public IEnumerable<Command> GetAll()
        {
            return new List<Command>
            {
                new Command{Id=1, HowTo="Boil an egg", Line="Boil water", Platform="Kettle"},
                new Command{Id=2, HowTo="Omlete an egg", Line="Boil water", Platform="Pan"},
                new Command{Id=3, HowTo="Scramble an egg", Line="Boil water", Platform="Pan"},
            };
        }
    }
}