using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    public interface IMember : INameable
    {
        List<ActivityHistoryItem> ActivityHistory { get; }
        void AddActivity(string description);

        List<ITask> Tasks { get; }
        void AddTask(ITask task);
        void RemoveTask(ITask task);
    }
}
