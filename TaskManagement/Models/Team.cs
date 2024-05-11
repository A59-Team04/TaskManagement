using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Team : ITeam
    {
        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        public const string NameIsNotUnique = "Team name is not unique.";

        private string _name;
        private List<IMember> _members = new List<IMember>();
        private List<IBoard> _boards = new List<IBoard>();
        private readonly List<ActivityHistoryItem> _activityHistory = new List<ActivityHistoryItem>();
        private List<Team> _teams = new List<Team>();


        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => _name;

            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLenght, MaxNameLenght, InvalidNameError);
                Validator.ValidateTeamNameUniqueness(value, NameIsNotUnique);

                _name = value;
            }
        }

        public List<IMember> Members
        {
            get
            {
                return new List<IMember>(_members);
            }
        }

        public bool IsBoardNameUnique(string boardName)
        {
            return !_boards.Any(board => board.Name == boardName);
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

        public List<IBoard> Boards
        {
            get
            {
                return new List<IBoard>(_boards);
            }
        }

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
