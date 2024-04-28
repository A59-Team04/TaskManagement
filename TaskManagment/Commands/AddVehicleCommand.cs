using TaskManagement.Core.Contracts;
using TaskManagement.Exceptions;

namespace TaskManagement.Commands
{
    public class AddVehicleCommand : BaseCommand
    {
        public AddVehicleCommand(List<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            throw new NotImplementedException();
        }

        private string AddVehicle(string make, string model, decimal price, string additionalParam)
        {
            throw new NotImplementedException();
        }
    }
}
