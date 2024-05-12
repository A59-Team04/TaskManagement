using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Member : IMember
    {
        private string _name;
        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        public const string NameIsNotUnique = "The member name already exists!";
        private List<ITask> _tasks = new List<ITask>();
        private readonly List<ActivityHistoryItem> _activityHistory = new List<ActivityHistoryItem>();

        public Member(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => _name;

            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLenght, MaxNameLenght, InvalidNameError);
                Validator.ValidateMemberNameUniqueness(value, NameIsNotUnique);

                _name = value;
            }
        }

        public List<ITask> Tasks
        {
            get
            {
                return new List<ITask>(_tasks);
            }
        }

        public List<ActivityHistoryItem> ActivityHistory
        {
            get
            {
                return new List<ActivityHistoryItem>(_activityHistory);
            }
        }

        public void CreateNewPerson()
        {

        }
        public void AddActivity(string description)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(ITask task)
        {
            _tasks.Remove(task);
        }

        public string ShowActivityHistory()
        {
            return string.Join(Environment.NewLine, _activityHistory.Select(e => e.ViewInfo())); // better check again
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
