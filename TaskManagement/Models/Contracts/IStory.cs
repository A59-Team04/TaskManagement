using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IStory
    {
        PriorityType Priority { get; }

        StoryStatus Status { get; }

        SizeType Size { get; } 
    }
}
