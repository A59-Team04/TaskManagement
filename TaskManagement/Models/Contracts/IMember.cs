using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    internal interface IMember : INameable
    {
        List<Task> Tasks { get; }
        List<string> ActivityHistory { get; }
    }
}
