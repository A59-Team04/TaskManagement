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
        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public int Id => throw new NotImplementedException();
    }
}
