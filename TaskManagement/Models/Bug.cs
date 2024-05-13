using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Bug : Task, IBug
    {

        private readonly List<string> _steps = new List<string>();
        private PriorityType _priority;
        private SeverityType _severity;
        private BugStatus _status;
        private IMember _assignee;
        private readonly List<IComment> _comment = new List<IComment>();
        private readonly List<IActivityHistoryItem> _activityHistory = new List<IActivityHistoryItem>();
        public Bug(int id,
                   string title,
                   string description,
                   PriorityType priorityType,
                   SeverityType severityType,
                   BugStatus status,
                   IMember assignee)
                   : base(id, title, description)
        {
            Priority = priorityType;
            Severity = severityType;
            BugStatus = status;
            Assignee = assignee;
        }

        public List<string> Steps
        {
            get
            {
                return new List<string>(_steps);
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


        public SeverityType Severity
        {
            get
            {
                return _severity;
            }
            set
            {
                _severity = value;
            }
        }

        public BugStatus BugStatus
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
        public List<IComment> Comments
        {
            get
            {
                return new List<IComment>(_comment);
            }
        }

        public List<IActivityHistoryItem> ActivityHistories
        {
            get
            {
                return new List<IActivityHistoryItem>(_activityHistory);
            }
        }

        public void ChangePriority(PriorityType priority)
        {
            Priority = priority;
            AddActivityHistory($"Priority changed to {priority}", _activityHistory);
        }

        public void ChangeSeverity(SeverityType severity)
        {
            Severity = severity;
            AddActivityHistory($"Severity changed to {severity}", _activityHistory);
        }

        public void ChangeStatus(BugStatus status)
        {
            BugStatus = status;
            AddActivityHistory($"Status changed to {status}", _activityHistory);
        }

        public override void AddComment(IComment comment)
        {
            _comment.Add(comment);
            AddActivityHistory($"Comment added to Story", _activityHistory);
        }

        public override void RemoveComment(IComment comment)
        {
            _comment.Remove(comment);
            AddActivityHistory($"Comment removed from Story", _activityHistory);
        }

        
    }
}
