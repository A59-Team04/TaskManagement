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
    public class ShowMemberActivity : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public ShowMemberActivity(IList<string> commandParameters, IRepository repository)
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

            return this.ShowMemberHistory(personName);
        }
        private string ShowMemberHistory(string personName)
        {
            IMember member = this.Repository.GetMember(personName);
            return member.ShowActivityHistory();
        }
    }
}
