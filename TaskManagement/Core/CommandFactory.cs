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
        private const char SplitCommandSymbol = ' ';
        private const string CommentOpenSymbol = "{{";
        private const string CommentCloseSymbol = "}}";

        private readonly IRepository repository;

        public CommandFactory(IRepository repository)
        {
            this.repository = repository;
        }

        public ICommand Create(string commandLine)
        {
            CommandType commandType = ParseCommandType(commandLine);
            List<string> commandParameters = this.ExtractCommandParameters(commandLine);

            switch (commandType)
            {
                //TO DO
                case CommandType.CreatePerson:
                    return new CreatePersonCommand(commandParameters, repository);
                case CommandType.ShowPeople:
                    throw new NotImplementedException();
                case CommandType.ShowPersonActivity:
                    throw new NotImplementedException();
                case CommandType.CreateTeam:
                    throw new NotImplementedException();
                case CommandType.ShowTeams:
                    throw new NotImplementedException();
                case CommandType.ShowTeamActivity:
                    throw new NotImplementedException();
                case CommandType.AddPersonToTeam:
                    throw new NotImplementedException();
                case CommandType.ShowTeamMembers:
                    throw new NotImplementedException();
                case CommandType.ShowTeamBoards:
                    throw new NotImplementedException();                
                case CommandType.ShowBoardActivity:
                    throw new NotImplementedException();
                default:
                    throw new InvalidUserInputException($"Command with name: {commandType} doesn't exist!");
            }
        }

        // Receives a full line and extracts the command to be executed from it.
        // For example, if the input line is "FilterBy Assignee John", the method will return "FilterBy".
        private CommandType ParseCommandType(string commandLine)
        {
            string commandName = commandLine.Split(SplitCommandSymbol)[0];
            Enum.TryParse(commandName, true, out CommandType result);
            return result;
        }

        // Receives a full line and extracts the parameters that are needed for the command to execute.
        // For example, if the input line is "FilterBy Assignee John",
        // the method will return a list of ["Assignee", "John"].
        private List<string> ExtractCommandParameters(string commandLine)
        {
            List<string> parameters = new List<string>();

            var indexOfOpenComment = commandLine.IndexOf(CommentOpenSymbol);
            var indexOfCloseComment = commandLine.IndexOf(CommentCloseSymbol);
            if (indexOfOpenComment >= 0)
            {
                var commentStartIndex = indexOfOpenComment + CommentOpenSymbol.Length;
                var commentLength = indexOfCloseComment - CommentCloseSymbol.Length - indexOfOpenComment;
                string commentParameter = commandLine.Substring(commentStartIndex, commentLength);
                parameters.Add(commentParameter);

                Regex regex = new Regex("{{.+(?=}})}}");
                commandLine = regex.Replace(commandLine, string.Empty);
            }

            var indexOfFirstSeparator = commandLine.IndexOf(SplitCommandSymbol);
            parameters.AddRange(commandLine.Substring(indexOfFirstSeparator + 1).Split(new[] { SplitCommandSymbol }, StringSplitOptions.RemoveEmptyEntries));

            return parameters;
        }
    }
}
