using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public abstract class Task : ITask
    {
        private const int TitleMinValue = 10;
        private const int TitleMaxValue = 50;
        private const int DescriptionMinValue = 10;
        private const int DescriptionMaxValue = 500;
        private readonly string TitleMessage = $"Title must be between {TitleMinValue} and {TitleMaxValue} symbols.";
        private readonly string DescriptionMessage = $"Description must be between {DescriptionMinValue} and {DescriptionMaxValue} symbols.";


        private readonly int _id;
        private string _title;
        private string _description;


        public Task(int id, string title, string description)
        {
            Title = title;
            Description = description;
            _id = id;
        }
        public string Title
        {
            get
            {
                return _title;
            }

            set
            {
                Validator.ValidateIntRange(value.Length, TitleMinValue, TitleMaxValue, TitleMessage);
                _title = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                Validator.ValidateIntRange(value.Length, DescriptionMinValue, DescriptionMaxValue, DescriptionMessage);
                _description = value;
            }
        }
        public int Id
        {
            get
            {
                return _id;
            }
        }

        public abstract void AddComment(IComment comment);
        public abstract void RemoveComment(IComment comment);

        static protected void AddActivityHistory(string description, List<IActivityHistoryItem> activityHistory)
        {
            var activity = new ActivityHistoryItem(description);
            activityHistory.Add(activity);
        }


    }
}
