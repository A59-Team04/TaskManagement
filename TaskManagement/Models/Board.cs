using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    internal class Board : IBoard, INameable
    {

        private string _name;
        private List<Board> _boards;
        private List<Task> _tasks;
        private List<ActivityHistory> _activityHistory;

        public Board(string name, List<Task> tasks, List<ActivityHistory> activityHistory)
        {
            _name = name;
            _tasks = tasks;
            _activityHistory = activityHistory;
        }

        public string Name
        {
            get
            {
                return this.make;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, MakeMinLength, MakeMaxLength, InvalidMakeError);
                Validator.ValidateUniqueness(value, List < Task > tasks,  )
                this.make = value;
            }
        }

        public List<Task> Tasks => throw new NotImplementedException();

        public List<string> ActivityHistory => throw new NotImplementedException();
    }
}
