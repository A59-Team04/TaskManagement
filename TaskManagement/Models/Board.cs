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
        public const int MinNameLength = 5;
        public const int MaxNameLength = 15;
        public const string InvalidNameError = "Name must be between 5 and 15 characters long!";
        public const string NameIsNotUnique = "The board name provided already exists!";

        private string _name;
        private readonly List<ITask> _tasks = new List<ITask>();
        private readonly List<IActivityHistoryItem> _boardHistory = new List<IActivityHistoryItem>();
        private ITeam _team;
        public Board(string name, ITeam team)
        {
            _name = name;
            Team = team;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, MinNameLength, MaxNameLength, InvalidNameError);
                Validator.ValidateBoardNameUniqueness(value, NameIsNotUnique);
                _name = value;
            }
        }

        public ITeam Team
        {
            get
            {
                return _team;
            }
            set
            {
                _team = value;
            }
        }

        public List<ITask> Tasks
        {
            get
            {
                return new List<ITask>(_tasks);
            }
        }

        public List<IActivityHistoryItem> ActivityHistory
        {
            get
            {
                return new List<IActivityHistoryItem>(_boardHistory);
            }
        }

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
            AddActivityHistory($"Task: {task} added to board.", _boardHistory);
        }

        public void RemoveTask(ITask task)
        {
            _tasks.Remove(task);
            AddActivityHistory($"Task: {task} removed from board.", _boardHistory);
        }
        private void AddActivityHistory(string description, List<IActivityHistoryItem> activityHistories)
        {
            var activity = new ActivityHistoryItem(description);
            activityHistories.Add(activity);
        }

    }
 }
