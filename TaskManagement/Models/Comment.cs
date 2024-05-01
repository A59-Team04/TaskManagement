using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public class Comment : IComment
    {

        public const int CommentMinLength = 3;
        public const int CommentMaxLength = 200;
        public const string InvalidCommentError = "Content must be between 3 and 200 characters long!";

        private const string CommentHeader = "    ----------";

        private string content;

        public Comment(string content, string author)
        {
            this.Content = content;
            this.Author = author;
        }

        public string Content
        {
            get
            {
                return this.content;
            }
            private set
            {
                Validator.ValidateIntRange(value.Length, CommentMinLength, CommentMaxLength, InvalidCommentError);
                this.content = value;
            }
        }

        public string Author { get; private set; }
    }
}
