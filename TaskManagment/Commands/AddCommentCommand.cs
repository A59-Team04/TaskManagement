using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;

namespace TaskManagement.Commands
{
    public class AddCommentCommand : BaseCommand
    {
        public AddCommentCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            if (this.CommandParameters.Count < 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 3, Received: {this.CommandParameters.Count}");
            }

            string content = this.CommandParameters[0];
            string author = this.CommandParameters[1];
            int vehicleIndex = this.ParseIntParameter(this.CommandParameters[2], "vehicleIndex") - 1;

            return this.AddComment(content, author, vehicleIndex);
        }

        private string AddComment(string content, string author, int vehicleIndex)
        {
            throw new NotImplementedException();
        }
    }
}
