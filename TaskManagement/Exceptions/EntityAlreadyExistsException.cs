using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Exceptions
{
    internal class EntityAlreadyExistsException : ApplicationException
    {
        public EntityAlreadyExistsException(string message)
    : base(message)
        {
        }
    }
}
