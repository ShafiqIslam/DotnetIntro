using DotnetIntro.Models;
using Microsoft.EntityFrameworkCore;

namespace DotnetIntro.Dal
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt): base(opt)
        {
            
        }

        public DbSet<Command> Commands { get; set; }
    }
}
