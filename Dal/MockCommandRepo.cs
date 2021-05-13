using System.Collections.Generic;
using DotnetIntro.Models;

namespace DotnetIntro.Dal
{
    public class MockCommandRepo : ICommandRepo
    {
        public void Add(Command command)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Command command)
        {
            throw new System.NotImplementedException();
        }

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

        public bool Save()
        {
            throw new System.NotImplementedException();
        }

        public void Update(Command command)
        {
            throw new System.NotImplementedException();
        }
    }
}