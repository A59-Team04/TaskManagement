﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Models.Enums;

namespace TaskManagement.Models.Contracts
{
    public interface IBug
    {
        PriorityType Priority { get; }

        SeverityType Severity { get; }

        BugStatus BugStatus { get; }
    }
}
