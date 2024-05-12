using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models.Contracts;
using TaskManagement.Models;

namespace TaskManagement.Commands
{
    public class ShowTeamMembersCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowTeamMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }

            var team = CommandParameters[0];  

            return ShowTeamMembers(team);

        }
        private string ShowTeamMembers(string team)
        {
            ITeam teamName = Repository.GetTeam(team);
            return teamName.PrintTeamMembers();
        }
    }
}
