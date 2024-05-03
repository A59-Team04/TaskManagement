using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Contracts;

namespace TaskManagement.Models
{
    public abstract class Task : ITask
    {
        private int _id;
        private string _title;
        private string _description;

        public Task(int id, string title, string description)
        {
           
        }
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();
    }
}
