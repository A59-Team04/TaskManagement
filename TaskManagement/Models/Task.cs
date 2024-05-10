using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Task : ITask, ICommentable
    {
        public static int titleMinLenght = 10;
        public static int titleMaxLenght = 50;
        public static string titcleLenghtError = $"The title must be between {titleMinLenght} and {titleMaxLenght} characters long";
        public static int descriptionMinLenght = 10;
        public static int descriptionMaxLenght = 500;
        public static string descriptionLenghtError = $"The descripton must be between {descriptionMinLenght} and {descriptionMaxLenght}characters long";

        private int _id;
        private string _title;
        private string _description;
        private readonly List<IComment> _comments;


        public Task(int id, string title, string description)
        {
            _id = id;
            _title = title;
            _description = description;
            _comments = new List<IComment>();
        }
        public string Title
        {
            get
            {
                return _title;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, titleMinLenght, titleMaxLenght, titcleLenghtError);
                _title = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, descriptionMinLenght, descriptionMaxLenght, descriptionLenghtError);
                _description = value;
            }
        }

        public int Id
        {
            get
            {
                return _id;
            }
            private set
            {
                // check uniqueness
                _id = value;
            }
        }
        public IList<IComment> Comments
        {
            get
            {
                var commentsCopy = new List<IComment>(this._comments);
                return commentsCopy;
            }
        }
        public void AddComment(IComment comment)
        {
            this._comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            this._comments.Remove(comment);
        }
    }
}
