using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Core.Contracts;

namespace TaskManagement.Commands
{
    public class ShowPeople : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;
        public ShowPeople(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }
    }
}
