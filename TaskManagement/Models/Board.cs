using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Board : IBoard, INameable
    {
        public const int MinNameLenght = 5;
        public const int MaxNameLenght = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        public const string NameIsNotUnique = "The board name provided already exists!";

        private string _name;
        private List<Task> _tasks;
        private readonly List<ActivityHistoryItem> _boardHistory;

        public Board(string name, List<Task> tasks, List<ActivityHistoryItem> activityHistory)
        {
            _name = name;
            _tasks = tasks;
            _boardHistory = activityHistory;
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
                //this.Team.IsBoardNameUnique(value); // TO DO
                _name = value;
            }
        }

        //private bool IsBoardNameUnique(string boardName)
        //{
        //    // Check if the board name already exists in the team's boards
        //    return !Team.Instance.Boards.Any(board => board.Name == boardName);
        //}
        public List<Task> Tasks
        {
            get
            {
                return new List<Task>(_tasks);
            }
        }

        public List<ActivityHistoryItem> ActivityHistory
        {
            get
            {
                return new List<ActivityHistoryItem>(_boardHistory);
            }
        }

    }
}
