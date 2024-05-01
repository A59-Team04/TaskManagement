using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    internal interface ITeam : INameable
    {
        List<IMember> Members { get; }
        List<IBoard> Boards { get; }
    }
}
