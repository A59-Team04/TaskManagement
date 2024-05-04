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
                Validator.ValidateIntRange(value.Length, MinNameLenght, MaxNameLenght, InvalidNameError);
                Validator.ValidateUniqueness(value, /* list of names ,*/ NameIsNotUnique);
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
