using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class CreateTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public CreateTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {

            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }
            string name = CommandParameters[0];
            ITeam team = this.Repository.CreateTeam(name);
            Repository.AddTeam(team);
            team.AddActivity($"New team with name {name} was created.");
            return $"New team with name {name} was created.";
        }
    }
}