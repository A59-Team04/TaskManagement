using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models
{
    public class Feedback : Task, IFeedback
    {
        private int _rating;
        FeedbackStatus _status;
        private readonly List<IComment> _comment = new List<IComment>();
        private readonly List<IActivityHistoryItem> _activityHistory = new List<IActivityHistoryItem>();

        public Feedback(int id, int rating, string title, string description, FeedbackStatus status = FeedbackStatus.New) : base(id, title, description)
        {
            Status = status;
            Rating = rating;
        }

        public FeedbackStatus Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }

        public int Rating
        {
            get
            {
                return _rating;
            }
            set
            {
                Validator.ValidateIntRange(value, 1, 5, "Rating must be between 1-5");
                _rating = value;
            }
        }

        public void ChangeRating (int newRating)
        {
            Rating = newRating;
            AddActivityHistory($"Rating changed to {newRating}", _activityHistory);
        }

        public void ChangeStatus (FeedbackStatus newStatus)
        {
            Status = newStatus;
            AddActivityHistory($"Status changed to {newStatus}", _activityHistory);
        }

        public override void AddComment(IComment comment)
        {
            _comment.Add(comment);
            AddActivityHistory($"Comment added to Feedback", _activityHistory);
        }

        public override void RemoveComment(IComment comment)
        {
            _comment.Remove(comment);
            AddActivityHistory($"Comment removed from Feedback", _activityHistory);
        }
    }
}
