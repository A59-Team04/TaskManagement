using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;

namespace TaskManagement.Commands
{
    public class CreateMemberCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 1;
        public CreateMemberCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (CommandParameters.Count != ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {CommandParameters.Count}");
            }
            string member = CommandParameters[0];

            // Create member
            var person = this.Repository.CreateMember(member);

            Repository.AddMember(person);

            return $"Member with name '{member}' was created!";

            
        }
    }
}
