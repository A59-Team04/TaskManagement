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
    public class CreateBoardCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;

        public CreateBoardCommand(IList<string> commandParameters, IRepository repository) : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException(
                    $"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }

            string boardName = CommandParameters[0];
            string teamName = CommandParameters[1];

            // Get the team
            ITeam team = Repository.GetTeam(teamName);

            // Create the board (assuming board name uniqueness is validated in Board constructor)
            IBoard board = new Board(boardName);

            // Add the board to the repository
            Repository.AddBoard(board);

            // You might want to add the board to the team here as well
            team.AddBoard(board);

            return $"Board '{boardName}' created in team '{teamName}' successfully!";
        }
    
    }
}
