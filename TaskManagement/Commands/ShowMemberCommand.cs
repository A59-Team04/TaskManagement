using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;

namespace TaskManagement.Commands
{
    public class ShowMemberCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 0;
        public ShowMemberCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {
            if (!this.Repository.Members.Any())
            {
                return "There are no created members yet.";
            }

            var stringBuilder = new StringBuilder();
            foreach (var member in this.Repository.Members)
            {
                stringBuilder.AppendLine(member.Name);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
