using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    internal class Member : IMember
    {
        // Check Activity History in Border. Correct in needed.

        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        private List<Task> _tasks;
        private List<string> _activityHistory;
        private string _name;

        public Member(string name, List<Task> tasks, List<string> activityHistory)
        {
            Name = name;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, MinNameLenght, MaxNameLenght, InvalidNameError);
                _name = value;
            }
        }
        public List<Task> Tasks
        {
            get
            {
                return _tasks;
            }
            private set
            {
                _tasks = new List<Task>();
            }
        }
        public List<string> ActivityHistory
        {
            get
            {
                return _activityHistory;
            }
            private set
            {
                _activityHistory = new List<string>();
            }
        }
    }
}
