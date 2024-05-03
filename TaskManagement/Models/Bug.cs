using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Bug : Task, IBugs
    {

        private IList<string> _steps = new List<string>();
        private PriorityType _priorityType;
        private SeverityType _severityType;
        private BugStatus _status;
        private IList<ITeam> _assignee = new List<ITeam>();
        private IList<IComment> _comment = new List<IComment>();
        private IList<string> _history = new List<string>();

        public Bug(int id,
                   string title,
                   string description,
                   IList<string> steps,
                   PriorityType priorityType,
                   SeverityType severityType,
                   BugStatus status,
                   IList<ITeam> assignee,
                   IList<IComment> comment,
                   IList<string> history)
                   : base(id, title, description)
        {
            _steps = steps;
            _priorityType = priorityType;
            _severityType = severityType;
            _status = status;
            _assignee = assignee;
            _comment = comment;
            _history = history;
        }

        public string Steps => throw new NotImplementedException();

        public PriorityType Priority => throw new NotImplementedException();

        public SeverityType Severity => throw new NotImplementedException();

        public BugStatus BugStatus => throw new NotImplementedException();
    }
}
