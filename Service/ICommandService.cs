﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface ICommandService<in T>
    {
        void Execute(T obj);
    }
}
