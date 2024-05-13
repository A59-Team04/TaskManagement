using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;

namespace TaskManagement.Commands
{
    public class ShowTeamsCommand : BaseCommand
    {
        public ShowTeamsCommand(IRepository repository)
            : base(repository)
        {
        }

        public override string Execute()
        {

            var stringBuilder = new StringBuilder();
            foreach (var team in this.Repository.Teams)
            {
                stringBuilder.AppendLine(team.Name);
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}
