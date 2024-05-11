using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;
using TaskManagement.Models;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Commands
{
    public class ShowTeamBoardsCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowTeamBoardsCommand(IList<string> commandParameters, IRepository repository)
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
            return ShowTeamBoards(team);

        }
        private string ShowTeamBoards(string team)
        {
            ITeam teamName = Repository.GetTeam(team);
            return teamName.PrintTeamBoards();
        }

    }
}
