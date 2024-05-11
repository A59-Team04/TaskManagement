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
    public class ShowAllMembersCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        public ShowAllMembersCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }

;           string personName = this.CommandParameters[0];

            return this.ShowMembers();
        }
        private string ShowMembers()
        {
            List<IMember> members = this.Repository.Members;
            return "finish"; // members.ShowAllPeople();
        }
    }
}
