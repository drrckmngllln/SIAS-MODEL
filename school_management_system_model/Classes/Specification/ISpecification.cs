﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_system_model.Classes.Specification
{
    internal interface ISpecification<T>
    {
        bool isPagingEnabled { get; }
    }
}