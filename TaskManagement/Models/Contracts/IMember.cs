using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
     public interface IMember : INameable
    {
        IList<ITask> Tasks { get; } 
        IList<string> ActivityHistory { get; }  

        void AddTask(ITask task);
        void RemoveTask(ITask task);
        void AddActivity(string activityDescription);
    }
}
