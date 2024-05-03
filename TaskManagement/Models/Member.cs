using System;
using System.Collections.Generic;
using System.Data;
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
        public const string NameIsNotUnique = "The name provided already exists!";

        private List<Task> _tasks;
        private List<string> _activityHistory;
        private string _name;
        private readonly List<IMember> _members;

        private readonly List<ActivityHistory> memberHistory = new List<ActivityHistory>();

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
                Validator.ValidateUniqueness(value, /* list of names ,*/ NameIsNotUnique);
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
        public void CreatePerson(IMember member)
        {
            _members.Add(member);
        }
        public void AssignTask(ITask task)
        {
            _tasks.Add(task);
        }
        public void UnassignTask(ITask task)
        {
            _tasks.Remove(task);
        }
        public void ShowActivityHistory()
        {

        }

        public static void ShowMemberActivity()
        {
            foreach (BoardItem item in Items)
            {
                Console.WriteLine(item.ViewHistory());
            }
        }
    }
}
