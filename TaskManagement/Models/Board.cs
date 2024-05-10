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
        public const string NameIsNotUnique = "The name provided already exists!";

        private string _name;
        private List<Task> _tasks;
        private readonly List<ActivityHistoryItem> _boardHistory;

        public Board(string name, List<Task> tasks, List<ActivityHistoryItem> activityHistory)
        {
            // Application.BoardNames.Add(name) Създавам нов статичен клас Appkication с лист от имена и с тази команда го запълвам
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
                // TODO: Validator.ValidateUniqueness(value, , NameIsNotUnique);
                _name = value;
            }
        }

        public List<Task> Tasks
        {
            get
            {
                return new List<Task>(_tasks);
            }
            // geter in AddTask method
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
