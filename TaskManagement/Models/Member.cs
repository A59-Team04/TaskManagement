using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Member : IMember
    {
        // Check Activity History in Border. Correct in needed.

        private const int MinNameLength = 5;
        private const int MaxNameLength = 15;
        private const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        private readonly IList<ITask> _tasks = new List<ITask>();
        private readonly IList<string> _activityHistory = new List<string>();
        private string _name;

        public Member(string name)
        {
           Name = name;
        }

        public IList<ITask> Tasks => _tasks;

        public IList<string> ActivityHistory => _activityHistory;

        public string Name
        {
            get => _name;

            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLength, MaxNameLength, InvalidNameError);
                _name = value;
            }
        }

        public void AddActivity(string activityDescription)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }

        public void RemoveTask(ITask task)
        {
            throw new NotImplementedException();
        }

    }
}
