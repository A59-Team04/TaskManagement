using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagement.Commands;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Story : Task, IStory
    {
        private PriorityType _priority;
        private SizeType _size;
        private StoryStatus _status;
        private IMember _assignee;
        private List<IComment> _comment = new List<IComment>();
        private readonly List<IActivityHistoryItem> _activityHistory = new List<IActivityHistoryItem>();
        public Story(int id,
                    string title,
                    string description,
                    IMember assignee,
                    PriorityType priority,
                    SizeType size)
                        : base(id, title, description)
        {
            Priority = priority;
            Size = size;
            Status = StoryStatus.NotDone;
            Assignee = assignee;

        }

        public List<IActivityHistoryItem> History
        {
            get
            {
                return new List<IActivityHistoryItem>(_activityHistory);
            }
        }
        public PriorityType Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
            }
        }
        public StoryStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public SizeType Size
        {
            get
            {
                return _size;
            }

            set
            {
                _size = value;
            }
        }

        public IMember Assignee
        {
            get
            {
                return _assignee;
            }
            set
            {
                _assignee = value;
            }
        }

        public void ChangePriority (PriorityType newPriority)
        {
            Priority = newPriority;
            AddActivityHistoryItem($"Priority changed to {newPriority}", _activityHistory);
        }

        public void ChangeSize (SizeType newSize)
        {
            Size = newSize;
            AddActivityHistoryItem($"Size changed to {newSize}", _activityHistory);
        }
        
        public void ChangeStatus (StoryStatus newStatus)
        {
            Status = newStatus;
            AddActivityHistoryItem($"Status changed to {newStatus}", _activityHistory);   
        }

        public void Assign (IMember member)
        {
            Assignee = member;
            AddActivityHistoryItem($"Assigned to {member.Name}", _activityHistory);
        }

        public override void AddComment(IComment comment)
        {
            _comment.Add(comment);
            AddActivityHistoryItem($"Comment added to Story", _activityHistory);
        }

        public override void RemoveComment(IComment comment)
        {
            _comment.Remove(comment);
            AddActivityHistoryItem($"Comment removed from Story", _activityHistory);
        }

    }
}
