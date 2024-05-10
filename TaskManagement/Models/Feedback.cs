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
        private IList<IComment> _comments = new List<IComment>();
        private IList<string> _history = new List<string>();
        public Feedback(int id, string title, string description, int rating, FeedbackStatus status, IList<IComment> comments, IList<string> histor) : base(id, title, description)
        {
            

        }

        public FeedbackStatus Status => throw new NotImplementedException();
    }
}
