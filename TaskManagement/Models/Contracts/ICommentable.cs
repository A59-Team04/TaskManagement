using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    public interface ICommentable
    {
        void AddComment(IComment comment);

        void RemoveComment(IComment comment);
    }
}
