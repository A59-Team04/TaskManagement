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
        private IList<ITeam> _assignee = new List<ITeam>();
        private IList<IComment> _comment = new List<IComment>();
        private IList<string> _history = new List<string>();
        public Story(int id, string title, string description) : base(id, title, description)
        {

        }

        public PriorityType Priority => throw new NotImplementedException();

        public StoryStatus Status => throw new NotImplementedException();

        public SizeType Size => throw new NotImplementedException();
    }
}
