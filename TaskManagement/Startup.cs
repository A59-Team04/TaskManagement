using TaskManagement.Core.Contracts;
using TaskManagement.Core;

namespace TaskManagement
{
    internal class Startup
    {
        static void Main(string[] args)
        {
            IRepository repository = new Repository();
            ICommandFactory commandFactory = new CommandFactory(repository);
            IEngine engine = new Core.Engine(commandFactory);
            engine.Start();
        }
    }
}
