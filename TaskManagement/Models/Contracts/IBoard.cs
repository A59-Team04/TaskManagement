using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    public interface IBoard : INameable
    {
        List<ITask> Tasks { get; }
        List<IActivityHistoryItem> ActivityHistory { get; }
    }
}
