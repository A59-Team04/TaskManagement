﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Models.Contracts
{
    public interface ITask
    {
        int Id { get; }
        string Title { get; }
        string Description { get; }

    }
}
