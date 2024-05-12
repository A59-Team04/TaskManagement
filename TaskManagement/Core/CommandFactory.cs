using TaskManagement.Commands;
using TaskManagement.Commands.Contracts;
using TaskManagement.Commands.Enums;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;

using System.Text.RegularExpressions;

namespace TaskManagement.Core
{
    public class CommandFactory : ICommandFactory
    { 

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            string[] arguments = commandLine.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            CommandType commandType = ParseCommandType(arguments[0]);
            List<string> commandParameters = ExtractCommandParameters(arguments);

            switch (commandType)
            {
                //TO DO
                case CommandType.CreateMember:
                    return new CreateMemberCommand(commandParameters, repository);
                case CommandType.ShowMembers:
                    return new ShowMemberCommand(repository);
                case CommandType.AddComment:
                    return new AddCommentCommand(commandParameters, repository);
                case CommandType.RemoveComment:
                    return new RemoveCommentCommand(commandParameters, repository);
                case CommandType.ShowMemberActivity:
                    throw new NotImplementedException();
                case CommandType.CreateTeam:
                    return new CreateTeamCommand(commandParameters, repository);
                case CommandType.ShowTeams:
                    return new ShowTeamsCommand(repository);
                case CommandType.ShowTeamActivity:
                    return new ShowTeamActivityCommand(commandParameters, repository);
                case CommandType.AddMemberToTeam:
                    return new AddMemberToTeamCommand(commandParameters, repository);
                case CommandType.ShowTeamMembers:
                    return new ShowTeamMembersCommand(commandParameters,repository);
                case CommandType.ShowTeamBoards:
                    return new ShowTeamBoardsCommand(commandParameters, repository);                
                case CommandType.ShowBoardActivity:
                    throw new NotImplementedException();
                case CommandType.CreateBoard:
                    return new CreateBoardCommand(commandParameters, repository);
                default:
                    throw new InvalidUserInputException($"Command with name: {arguments[0]} doesn't exist!");
            }
        }

        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private static CommandType ParseCommandType(string value)
        {
            if(Enum.TryParse(value, true, out CommandType result))
            {
                return result;
            }
            else
            {
                return CommandType.Invalid;
            }
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private static List<String> ExtractCommandParameters(string[] arguments)
        {
            List<string> commandParameters = new List<string>();

            for (int i = 1; i < arguments.Length; i++)
            {
                commandParameters.Add(arguments[i]);
            }

            return commandParameters;
        }
    }
}
