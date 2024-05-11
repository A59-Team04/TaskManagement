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
    public class ShowTeamActivityCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowTeamActivityCommand(IList<string> commandParameters, IRepository repository) 
            : base(commandParameters, repository) 
        { 
        }
        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }

            string teamName = this.CommandParameters[0];

            return this.ShowMemberHistory(teamName);
        }
        private string ShowMemberHistory(string teamName)
        {
            IMember member = this.Repository.GetMember(teamName);
            return member.ShowActivityHistory();
        }
    }
}
