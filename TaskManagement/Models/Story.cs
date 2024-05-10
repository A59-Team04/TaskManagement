using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Story : Task, IStory
    {
        private PriorityType _priorityType;
        private SizeType _sizeType;
        private StoryStatus _status;
        private IList<ITeam> _assignee = new List<ITeam>(); // don't think that is correct, reconsider how to assign story
        private IList<IComment> _comment = new List<IComment>();
        private IList<string> _history = new List<string>(); // don't think history is a list of strings, consider how to implement activity history.
        public Story(int id,
                     string title, 
                     string description, 
                     PriorityType priority, 
                     SizeType size, 
                     StoryStatus status,
                     IList<ITeam> assignee,
                     IList<IComment> comment,
                     IList<string> history) 
                     : base(id, title, description)
        {
            _priorityType = priority;
            _sizeType = size;
            _status = status;
            _assignee = assignee;
            _comment = comment;
            _history = history;
        }

        public PriorityType Priority { get; private set; }

        public StoryStatus Status { get; private set; }

        public SizeType Size { get; private set; }
    }
}
