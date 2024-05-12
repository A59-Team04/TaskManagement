using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Exceptions;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Team : ITeam, INameable
    {
        public const int MinNameLength = 5;
        public const int MaxNameLength = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        public const string NameIsNotUnique = "Team name already exists!";

        private string _name;
        private readonly List<IMember> _members = new List<IMember>();
        private readonly List<IBoard> _boards = new List<IBoard>();
        private readonly List<ActivityHistoryItem> _activityHistory = new List<ActivityHistoryItem>();

        public Team(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get => _name;

            set
            {
                Validator.ValidateIntRange(value.Length, MinNameLength, MaxNameLength, InvalidNameError);
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
            if (_members.Contains(member))
            {
                throw new EntityAlreadyExistsException($"Member with already exists!");
            }
            AddActivity($"Member '{member}' added to Team: {Name}");
            _members.Add(member);
            
        }

        public void RemoveMember(IMember member)
        {
            AddActivity($"Member '{member}' removed from Team: {Name}");
            _members.Remove(member);
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
            if (_boards.Contains(board))
            {
                throw new EntityAlreadyExistsException("Board already exists!");
            }
            AddActivity($"Board '{board}' added to Team: {Name}");
            _boards.Add(board); 
        }

        public void RemoveBoard(IBoard board)
        {
            AddActivity($"Board '{board}' removed from Team: {Name}");
            _boards.Remove(board);
        }

        public string PrintTeamBoards()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"--Team: {Name}--");
            if (_boards.Count == 0)
            {
                result.AppendLine($"No boards in Team: {Name}");
                return result.ToString();
            }

            int boardCount = 1;

            foreach (var board in _boards)
            {
                result.Append(boardCount++);
                result.AppendLine(board.ToString());
            }
            return result.ToString();
        }

    }
}
