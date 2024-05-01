using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    public interface ITask
    {
        string Title { get; }

        string Description { get; }

        // Status {get; }

        List<Bug> Bugs { get; }

        List<Story> Stories {  get; }

        List<Feedback> Feedbacks { get; }

    }
}
