using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    internal interface IActivityHistory
    {
        private const string DateFormat = "dd-MM-yyyy";

        private readonly List<Activity> activities = new List<Activity>();

    }
}
