using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Member : Application , IMember
    {

        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        public const string NameIsNotUnique = "The name provided already exists!";

        private List<Task> _tasks;     
        private string _name;
        private readonly List<ActivityHistory> _memberHistory = new List<ActivityHistory>();

        public Member(string name)
        {
            _name = name;
            memberNames.Add(name);
            _tasks = new List<Task>();
            _memberHistory = new List<ActivityHistory>();
        }


        public string Name
        {
            get => _name;

            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLenght, MaxNameLenght, InvalidNameError);
                Validator.ValidateUniqueness(value, memberNames, NameIsNotUnique);
                _name = value;
            }
        }

        public List<Task> Tasks
        {
            get => _tasks;
            set => _tasks = value ?? throw new ArgumentNullException(nameof(value), "Tasks list cannot be null"); // not sure Check again.
        }

        public List<ActivityHistory> MemberHystory
        {
            get => _memberHistory;
        }

        public void AddActivity(string activityDescription)
        {
            throw new NotImplementedException();
        }

        public void AddTask(ITask task)
        {
            throw new NotImplementedException();
        }
        //public void CreatePerson(Member member)    FOR TEAMS
        //{
        //    _members.Add(member);
        //}
        public void AssignTask(Task task) // is it going to work like that??
        {
            _tasks.Add(task);
        }
        public void UnassignTask(Task task) // is it going to work like that??
        {
            _tasks.Remove(task);
        }

        public static void ShowMemberActivity()
        {
            return string.Join(Environment.NewLine, _memberHistory.Select(e => e.ViewInfo())); // why not working ?
        }

        public void RemoveTask(ITask task)
        {
            throw new NotImplementedException();
        }
    }
}
