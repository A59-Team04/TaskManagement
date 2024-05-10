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
        private IList<string> _history = new List<string>();
        public Feedback(int id, string title, string description, FeedbackStatus status) : base(id, title, description)
        {
            Status = FeedbackStatus.New;
        }

        public FeedbackStatus Status
        {
            get => _status;
            private set => _status = value;
        }

    }
}
