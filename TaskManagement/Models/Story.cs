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
        private PriorityType _priority;
        private SizeType _size;
        private StoryStatus _status;
        private IList<IMember> _assignee = new List<IMember>();
        private IList<string> _history = new List<string>();
        public Story(int id, string title, string description, IMember assignee, PriorityType priority, SizeType size) : base(id, title, description)
        {
            Priority = priority;
            Size = size;
            Status = StoryStatus.NotDone;

        }
        public IList<IMember> Assignee =>  new List<IMember>(_assignee);
        public IList<string> History =>  new List<string>(_history);
        public PriorityType Priority
        {
            get => _priority;
            private set
            {
                _priority = value;
            }
        }
        public StoryStatus Status
        {
            get => _status;
            private set
            {
                _status = value;
            }
        }
        public SizeType Size
        {
            get => _size;
            private set
            {
                _size = value;
            }
        }
    }
}
