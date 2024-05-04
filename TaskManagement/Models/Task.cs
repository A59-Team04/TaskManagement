using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    internal class Task : ITask
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

        public Task(int id, string title, string description)
        {
            _id = id;
            _title = title;
            _description = description;
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
            }
        }

        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();
    }
}
