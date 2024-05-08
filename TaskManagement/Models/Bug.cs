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

        private IList<string> _steps = new List<string>();
        private PriorityType _priorityType;
        private SeverityType _severityType;
        private BugStatus _status;
        private IList<IMember> _assignee = new List<IMember>();
        private IList<string> _history = new List<string>();

        public Bug(int id,
                   string title,
                   string description,
                   PriorityType priorityType,
                   SeverityType severityType,
                   BugStatus status,
                   IMember assignee,
                   IList<string> history)
                   : base(id, title, description)
        {
            _priorityType = priorityType;
            _severityType = severityType;
            _status = status;
            _history = history;
        }

        public string Steps => throw new NotImplementedException();

        public PriorityType Priority => throw new NotImplementedException();

        public SeverityType Severity => throw new NotImplementedException();

        public BugStatus BugStatus => throw new NotImplementedException();
    }
}
