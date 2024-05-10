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
    public class RemoveCommentCommand : BaseCommand
    {
        public RemoveCommentCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 3)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: 3, Received: {this.CommandParameters.Count}");
            }

            string content = this.CommandParameters[0];
            string author = this.CommandParameters[1];
            int taskId = this.ParseIntParameter(this.CommandParameters[2], "Task ID") - 1;

            return this.AddComment(content, author, taskId);
        }

        private string AddComment(string content, string author, int taskId)
        {
            //IUser user = this.Repository.GetUser(author);

            //Validator.ValidateIntRange(
            //    taskId,
            //    0,
            //    user.Vehicles.Count,
            //    "The vehicle does not exist!");

            //IVehicle vehicle = user.Vehicles[taskId];

            //IComment comment = this.Repository.CreateComment(content, this.Repository.LoggedUser.Username);

            //this.Repository.LoggedUser.AddComment(comment, vehicle);

            //return $"{this.Repository.LoggedUser.Username} added comment successfully!";

            // TODO: Implement AddCommentCommand
            throw new NotImplementedException();
        }
    }
}
