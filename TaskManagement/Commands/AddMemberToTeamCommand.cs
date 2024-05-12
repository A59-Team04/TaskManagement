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
    public class AddMemberToTeamCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 2;
        public AddMemberToTeamCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }
        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }
            
            string memberName = CommandParameters[0];
            string teamName = CommandParameters[1];

            IMember member = Repository.GetMember(memberName);
            ITeam team = Repository.GetTeam(teamName);
            
            team.AddMember(member);

            return $"Member '{memberName}' added to team '{teamName}' successfully";
        }
    }
}
