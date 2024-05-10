using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    internal class Team : ITeam
    {
        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";

        private string _name;
        private List<Member> _members = new List<Member>();
        private List<Board> _board = new List<Board>();
        private readonly List<ActivityHistoryItem> _activityHistory = new List<ActivityHistoryItem>();


        public Team(string name)
        {

        }

        public string Name
        {
            get
            {
                return _name;
            }
        }

        public List<IMember> Members
        {
            get
            {
                return new List<IMember>(_members);
            }
        }

        public void ShowAllMembers()
        {
            Console.WriteLine($"{this.Name}:");

            foreach (var member in _members)
            {
                Console.WriteLine(member.Name);
            }

        }

        public string ShowActivityHistory()
        {
            return string.Join(Environment.NewLine, _activityHistory.Select(e => e.ViewInfo())); // better check again
        }

        public void AddActivity(string description)
        {
            _activityHistory.Add(new ActivityHistoryItem(description));
        }


        public void AddMember(IMember member)
        {
            throw new NotImplementedException();
        }

        public void RemoveMember(IMember member)
        {
            throw new NotImplementedException();
        }

        List<IBoard> ITeam.Boards { get; }

        public void AddBoard(IBoard board)
        {
            throw new NotImplementedException();
        }

        public void RemoveBoard(IBoard board)
        {
            throw new NotImplementedException();
        }
    }
}
